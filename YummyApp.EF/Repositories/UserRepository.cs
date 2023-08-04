using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Repositories;
using YummyApp.EF.Data;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using YummyApp.Core.Models;

namespace YummyApp.EF.Repositories
{
    public class UserRepository : IUserRepository<ApplicationUser> 
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        

        public async void DeleteAsync(ApplicationUser entity)
        {
            var userRoles = await _userManager.GetRolesAsync(entity);

            var result = await _userManager.DeleteAsync(entity);

            if (result.Succeeded)
            {
                if (userRoles.Any())
                {
                    foreach (var role in userRoles)
                    {
                        await _userManager.RemoveFromRoleAsync(entity, role);
                    }
                }
            }
        }


        //public ApplicationUser Find(Expression<Func<ApplicationUser, bool>> criteria, string[] includes = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<ApplicationUser> FindAll(Expression<Func<ApplicationUser, bool>> criteria, string[] includes = null)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _userManager.Users.Where(x => x.Blocked == 0).ToList();
        }
        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> criteria)
        {
            return _userManager.Users.Where(criteria).ToList();
        }

        public ApplicationUser GetById(string id)
        {
            return  _userManager.FindByIdAsync(id).Result; 
        }

        public ApplicationUser Update(ApplicationUser entity)
        {
            var result =  _userManager.UpdateAsync(entity).Result;
            if (result.Succeeded)
            {
                 _context.SaveChanges(); // Save the changes to the database
            }

            return entity;
        }


        public object DataTableAllData(HttpRequest request)
        {
            var pageSize = int.Parse(request.Form["length"]);
            var skip = int.Parse(request.Form["start"]);

            string searchValue = request.Form["search[value]"];

            var sortColumn = request.Form[string.Concat("columns[", request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = request.Form["order[0][dir]"];

            IQueryable<ApplicationUser> users = _userManager.Users.AsQueryable();
            users = users.Where(u => u.UserType == UserType.Chef);
            users = users.Where(u => u.Blocked == 0);

            if (!string.IsNullOrEmpty(searchValue))
            {
                users = users.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : 
                (x.FirstName.Contains(searchValue)) ||
                (x.LastName.Contains(searchValue)) ||
                (x.Email.Contains(searchValue)));
            }

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                users = users.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = users.Skip(skip).Take(pageSize).ToList();
            var recordsTotal = _userManager.Users.Count();
            var recordsFiltered = users.Count();

            var jsonData = new
            {
                recordsFiltered,
                recordsTotal,
                data
            };
            return jsonData;
        }

		public int Count(Expression<Func<ApplicationUser, bool>> criteria)
		{
            return _userManager.Users.Count(criteria);
		}
	}
}
