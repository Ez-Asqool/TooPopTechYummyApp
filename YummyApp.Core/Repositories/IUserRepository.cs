using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Models;

namespace YummyApp.Core.Repositories
{
    public interface IUserRepository<T> where T : class
    {
        T GetById(string id);

        IEnumerable<T> GetAll();

        IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> criteria);

        //T Find(Expression<Func<T, bool>> criteria, string[] includes = null);

        //IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);

        T Update(T entity);

        void DeleteAsync(T entity);

		int Count(Expression<Func<T, bool>> criteria);

		public object DataTableAllData(HttpRequest request);
    }
}
