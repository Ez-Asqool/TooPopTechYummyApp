using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.Repositories;
using YummyApp.EF.Data;
using YummyApp.EF.Repositories;

namespace YummyApp.EF
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public IBaseRepository<Contact> Contacts { get; private set; }

        public IEventsRepository Events { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Contacts = new BaseRepository<Contact>(_context);
            Events = new EventsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
