using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.AdminModels;

namespace YummyApp.Core.Repositories
{
    public interface IEventsRepository : IBaseRepository<Event>
    {

        public object DataTableAlldata(HttpRequest Request);
    }
}
