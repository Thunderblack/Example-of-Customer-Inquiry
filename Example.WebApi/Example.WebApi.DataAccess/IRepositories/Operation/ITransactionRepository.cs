using Example.WebApi.DataAccess.Model.Database.Operation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.IRepositories
{
    public interface ITransactionRepository
    {
        Transactions FindTransaction(long id);
        List<Transactions> FindAllTransaction(long customerCode);
        List<Transactions> FindRecentlyTransaction(long customerCode);
        void Create(Transactions data);
        void Update(Transactions data);
    }
}
