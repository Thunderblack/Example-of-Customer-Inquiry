using Example.WebApi.DataAccess.IRepositories;
using Example.WebApi.DataAccess.Model.Database.Operation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.WebApi.DataAccess.Repositories
{
    public class TransactionRepository : RepositoryBase, ITransactionRepository
    {
        public TransactionRepository(ApplicationDbContext context) : base(context) { }

        public void Create(Transactions data)
        {
            if (data == null) throw new Exception("A transaction information cannot be null");

            _context.Transactionses.Add(data);
        }

        public void Update(Transactions data)
        {
            if (data == null) throw new Exception("A transaction information cannot be null");

            var info = FindTransaction(data.id);
            if (info != null)
            {
                info.amount = data.amount;
                info.date = data.date;
                info.currency = data.currency;
                info.status = data.status;

                _context.Entry(info).State = EntityState.Modified;
            }
            else throw new Exception("Transaction Not Found");
        }

        public Transactions FindTransaction(long id)
        {
            return _context.Transactionses
                           .Where(x => x.id.Equals(id))
                           .Select(x => x)
                           .FirstOrDefault();
        }

        public List<Transactions> FindAllTransaction(long customerCode)
        {
            return _context.Transactionses
                           .Where(x => x.customerID.Equals(customerCode))
                           .Select(x => x)
                           .ToList();
        }

        public List<Transactions> FindRecentlyTransaction(long customerCode)
        {
            int noTransaction = Common.AppConstants.fetchNoOfRecently;

            return FindAllTransaction(customerCode)
                       .OrderByDescending(x => x.date)
                       .Take(noTransaction)
                       .Select(x => x)
                       .ToList();
        }
    }
}
