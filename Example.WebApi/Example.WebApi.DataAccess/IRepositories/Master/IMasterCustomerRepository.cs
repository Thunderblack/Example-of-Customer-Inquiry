using Example.WebApi.DataAccess.Model.Database.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.IRepositories
{
    public interface IMasterCustomerRepository
    {
        Customers FindOneOfCustomer(long id, string email);
        void Create(Customers data);
        void Update(Customers data);
    }
}
