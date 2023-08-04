using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Repositories;
using YummyApp.EF.Data;
using System.Linq.Dynamic.Core;
using YummyApp.Core.Models.HomeModels;
using Microsoft.EntityFrameworkCore;
using YummyApp.Core.ViewModels.ChefViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Logging;

namespace YummyApp.EF.Repositories
{
    internal class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public object DataTableAlldata(HttpRequest Request)
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            string searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            
            IQueryable<Contact> contacts = _context.Contacts.Where(x => x.Blocked == 0).AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                contacts = contacts.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : 
                (x.Name.Contains(searchValue)) ||
                (x.Message.Contains(searchValue)) ||
                (x.Email.Contains(searchValue)));
            }

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                contacts = contacts.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = contacts.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = contacts.Count();

            var jsonData = new
            {
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            };

            return jsonData;
        }


    }
}
