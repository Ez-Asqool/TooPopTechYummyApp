using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Models.HomeModels;
using YummyApp.Core.Repositories;

namespace YummyApp.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<MenuCategory> MenuCategory { get; }
        IBaseRepository<Photo> Photo { get; }
        IBookRepository Book { get; }
        IEventsRepository Events { get; }
        IMealsRepository Meals { get; }
        IContactRepository Contacts { get; }

        IPhotoAlbumRepository PhotoAlbum { get; }

        //IChefRepository<> Users { get; }

        int Complete();
    }
}
