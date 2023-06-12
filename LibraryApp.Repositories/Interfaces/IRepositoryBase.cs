using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories.Interfaces
{
    public  interface IRepositoryBase<T> where T : class
    {
        public List<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        List<T> Find(Expression<Func<T, bool>> predicate);
        T? Find(Expression<Func<T, bool>> predicate, List<string>? includes);
        List<T> FindIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        bool DoesExist(Expression<Func<T, bool>> predicate);
        
    }
}
