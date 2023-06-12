using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibraryApp.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected IDbContext Context;
        private readonly DbSet<T> _table;

        protected RepositoryBase(IDbContext context)
        {
            Context = context;
            _table = Context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T? GetById(int id)
        { 
            return _table.Find(id); 
        }
        
        public void Add(T entity) 
        {
            _table.Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }
        
        public void Update(T entity)
        {
                        
            _table.Update(entity);            
            
        }
        
        public void Remove(T entity)
        {
            _table.Remove(entity); 
        }
        
        public void RemoveRange(IEnumerable<T> entities)
        {
            _table.RemoveRange(entities);
        }
        
        public List<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).ToList();
        }
        
        public T? Find(Expression<Func<T, bool>> predicate, List<string>? includes)
        {
            IQueryable<T> query = _table;
            
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return  query.FirstOrDefault(predicate);
        }

        /*
        public List<T> FindEntities(Expression<Func<T, bool>> predicate, List<string>? includes)
        {
            IQueryable<T> query = _table;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query.Where(predicate).ToList();
        }
        */

        public List<T> FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach(var include in includes)
            {
                query = query.Include(include);
            }

            return query.Where(predicate).ToList();
        }
        
        public bool DoesExist(Expression<Func<T, bool>> predicate)
        {
            return _table.Any(predicate);
        }
    }
}
