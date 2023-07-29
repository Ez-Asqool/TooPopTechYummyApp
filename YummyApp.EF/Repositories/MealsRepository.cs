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

namespace YummyApp.EF.Repositories
{
    internal class MealsRepository : BaseRepository<Meal>, IMealsRepository
    {
        private readonly ApplicationDbContext _context;
        public MealsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public object DataTableAlldata(HttpRequest Request, string userId)
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            string searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            
            IQueryable<Meal> meals = _context.Meals.Include(x => x.Category).Where(x => x.ApplicationUserId == userId && x.Blocked == 0).AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                meals = meals.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : (x.Price.ToString().Contains(searchValue)) ||
                (x.Name.Contains(searchValue)) ||
                (x.Category.Name.Contains(searchValue)));
            }

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                meals = meals.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = meals.Skip(skip).Take(pageSize).Select(item => new MealVM
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                ImageName = item.ImageName,
                Category = item.Category.Name
            }).ToList();

            var recordsTotal = meals.Count();

            //List<MealVM> data = new List<MealVM>();
            
            //foreach (var item in allData)
            //{
            //    data.Add(
            //        new MealVM { 

            //        }
            //    );
            //}

            var jsonData = new
            {
                recordsFiltered = recordsTotal,
                recordsTotal,
                data
            };

            return jsonData;
        }


        //public object DataTableAlldata(HttpRequest Request)
        //{
        //    var pageSize = int.Parse(Request.Form["length"]);
        //    var skip = int.Parse(Request.Form["start"]);

        //    string searchValue = Request.Form["search[value]"];

        //    var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
        //    var sortColumnDirection = Request.Form["order[0][dir]"];

        //    IQueryable<Meal> meals = _context.Meals/*.Include(x => x.Category)*/.AsQueryable();
        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        meals = meals.Where(x =>
        //        string.IsNullOrEmpty(searchValue) ? true : (x.Price.ToString().Contains(searchValue)) ||
        //        (x.Name.Contains(searchValue)) ||
        //        (x.Category.Name.Contains(searchValue)));
        //    }


        //    //IQueryable<Event> events = _context.Events.Where(x =>
        //    //    string.IsNullOrEmpty(seairchValue)? true: (x.Price.ToString().Contains(searchValue)) ||
        //    //    (x.Title.Contains(searchValue)) ||
        //    //    (x.Description.Contains(searchValue))
        //    //);

        //    if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        //    {
        //        meals = meals.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
        //    }

        //    var data = meals.Skip(skip).Take(pageSize).ToList();


        //    var recordsTotal = meals.Count();

        //    var jsonData = new
        //    {
        //        recordsFiltered = recordsTotal,
        //        recordsTotal,
        //        data
        //    };
        //    return jsonData;
        //}
    }
}
