using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.IRepositories
{
    public interface IMasterTransactionStatusRepository
    {
        string FindStatusDescription(string code);
    }
}
