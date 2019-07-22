using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.IRepositories
{
    public interface IMasterCustomerStatusRepository
    {
        string FindStatusDescription(string code);
    }
}
