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

namespace YummyApp.EF.Repositories
{
    internal class EventsRepository : BaseRepository<Event>, IEventsRepository
    {
        private readonly ApplicationDbContext _context;
        public EventsRepository(ApplicationDbContext context) : base(context)
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

            IQueryable<Event> events = _context.Events.AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                events = events.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : (x.Price.ToString().Contains(searchValue)) ||
                (x.Title.Contains(searchValue)) ||
                (x.Description.Contains(searchValue)));
            }


            //IQueryable<Event> events = _context.Events.Where(x =>
            //    string.IsNullOrEmpty(seairchValue)? true: (x.Price.ToString().Contains(searchValue)) ||
            //    (x.Title.Contains(searchValue)) ||
            //    (x.Description.Contains(searchValue))
            //);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                events = events.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = events.Skip(skip).Take(pageSize).ToList();


            var recordsTotal = events.Count();

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
