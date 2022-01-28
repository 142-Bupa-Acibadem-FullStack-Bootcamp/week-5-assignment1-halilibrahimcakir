using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Update(T entity);
        T Delete(T entity);
        T GetById(int id);
    }
}
