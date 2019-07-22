using Example.WebApi.DataAccess.IRepositories;
using Example.WebApi.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Example.WebApi.DataAccess.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext _context;
        #region "Master Table"
        private IMasterCustomerRepository _masterCustomerRepository;
        #endregion "Master Table"

        #region "Operation Table"
        private ITransactionRepository _transactionRepository;
        #endregion "Operation Table"

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        #region "Master Table - Repository"
        public IMasterCustomerRepository MasterCustomerRepository
        {
            get
            {
                if (this._masterCustomerRepository == null)
                {
                    this._masterCustomerRepository = new MasterCustomerRepository(_context);
                }

                return this._masterCustomerRepository;
            }
        }
        #endregion "Master Table - Repository"

        #region "Operation Table - Repository"
        public ITransactionRepository TransactionRepository
        {
            get
            {
                if (this._transactionRepository == null)
                {
                    this._transactionRepository = new TransactionRepository(_context);
                }

                return this._transactionRepository;
            }
        }
        #endregion "Operation Table - Repository"

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
