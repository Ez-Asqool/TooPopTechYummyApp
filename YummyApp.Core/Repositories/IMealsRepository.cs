using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models.AdminModels;
using YummyApp.Core.Models.HomeModels;

namespace YummyApp.Core.Repositories
{
    public interface IMealsRepository : IBaseRepository<Meal>
    {

        public object DataTableAlldata(HttpRequest Request, string userId);
    }
}
