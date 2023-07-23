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
        IBaseRepository<Contact> Contacts { get; }
        IEventsRepository Events { get; }

        int Complete();
    }
}
