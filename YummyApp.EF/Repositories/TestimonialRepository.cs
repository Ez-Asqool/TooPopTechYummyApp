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
    internal class TestimonialRepository : BaseRepository<Testimonial>, ITestimonialRepository
    {
        private readonly ApplicationDbContext _context;
        public TestimonialRepository(ApplicationDbContext context) : base(context)
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

            
            IQueryable<Testimonial> testimonials = _context.Testimonials.Where(x => x.Blocked == 0).AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                testimonials = testimonials.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : 
                (x.Name.Contains(searchValue)) ||
                (x.JobTitle.Contains(searchValue)) ||
                (x.Stars.ToString().Contains(searchValue)));
            }

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                testimonials = testimonials.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = testimonials.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = testimonials.Count();

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
