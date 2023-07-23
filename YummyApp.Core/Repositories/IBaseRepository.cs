using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.Core.Repositories
{
    public interface IBaseRepository<T> where T: class
    {

        T GetById(int id);  
        Task<T> GetByIdAsunc(int id);

        IEnumerable<T> GetAll();    

        T Add(T entity);
        
        IEnumerable<T> AddRange(IEnumerable<T> entities);

        T Find(Expression<Func<T, bool>> criteria, string[] includes = null);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null);

        T Update(T entity);

        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        void Attach(T entity);

        int Count();
        
        int Count(Expression<Func<T, bool>> criteria);


        //Object DataTableAlldata(Object Request);


    }
}
