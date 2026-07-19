using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MonitorShop.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        List<T> Find(Expression<Func<T, bool>> predicate);
    }
}
