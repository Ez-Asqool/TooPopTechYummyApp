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
using YummyApp.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace YummyApp.EF.Repositories
{
    internal class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
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

            
            IQueryable<Book> books = _context.Books.Where(x => x.Blocked == 0).AsQueryable();
            if (!string.IsNullOrEmpty(searchValue))
            {
                books = books.Where(x =>
                string.IsNullOrEmpty(searchValue) ? true : 
                (x.Name.Contains(searchValue)) ||
                (x.NumberOfPeople.ToString().Contains(searchValue)) ||
                (x.Date.Contains(searchValue)) ||
                (x.Time.Contains(searchValue)));
            }

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                books = books.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = books.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = books.Count();

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
