using Microsoft.EntityFrameworkCore;
using Northwind.Data.Context;
using Northwind.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Variable
        private readonly DbContext _context;
        #endregion

        #region Ctor
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        #endregion

        #region  Repository
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new RepositoryBase<T>(_context);
        }
        #endregion

        #region Transactions
        public void SaveChanges()
        {
            using (_context.Database.BeginTransaction())
            {
                try
                {
                    if (_context == null)
                    {
                        throw new ArgumentException("Context is null");
                    }
                    else
                    {
                        _context.SaveChanges();
                        _context.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    _context.Database.CurrentTransaction.Rollback();

                    throw new Exception("Error on save changes", ex);
                }
            }
        }
        #endregion

        #region Disposable
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                _context.Dispose();

            disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
