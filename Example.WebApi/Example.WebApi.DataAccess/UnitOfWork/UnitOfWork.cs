using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Example.WebApi.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveTransactionScope()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _context.SaveChanges();
                scope.Complete();
            }
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion IDisposable
    }
}
