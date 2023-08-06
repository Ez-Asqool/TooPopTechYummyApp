using Microsoft.AspNetCore.Identity;
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
        public IBaseRepository<MenuCategory> MenuCategory { get; private set; }
        public IBaseRepository<Photo> Photo { get; private set; }
        public IBookRepository Book { get; private set; }
        
        public IPhotoAlbumRepository PhotoAlbum { get; private set; }
        public IEventsRepository Events { get; private set; }
        public IMealsRepository Meals { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public ITestimonialRepository Testimonials { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
            MenuCategory = new BaseRepository<MenuCategory>(_context);
            Photo = new BaseRepository<Photo>(_context);
            Book = new BookRepository(_context);
            Events = new EventsRepository(_context);
            Meals = new MealsRepository(_context);
            PhotoAlbum = new PhotoAlbumRepository(_context);
            Testimonials = new TestimonialRepository(_context); 
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
