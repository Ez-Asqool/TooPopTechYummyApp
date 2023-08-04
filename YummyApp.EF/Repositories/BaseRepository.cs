using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YummyApp.Core.Repositories;
using YummyApp.EF.Data;

namespace YummyApp.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsunc(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);  
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            return entities;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList(); ;
        }

        public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();    
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.SingleOrDefault(criteria);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.Where(criteria).ToList();
        }


        public IEnumerable<T> FindAll(string[] includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query.ToList();
        }


        public T Update(T entity) {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity) {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Attach(T entity) { 
            _context.Set<T>().Attach(entity);   
        }

        public int Count() {
            return _context.Set<T>().Count();
        }

        public int Count(Expression<Func<T, bool>> criteria) { 
            return _context.Set<T>().Count(criteria);
        }

        
    }
}
