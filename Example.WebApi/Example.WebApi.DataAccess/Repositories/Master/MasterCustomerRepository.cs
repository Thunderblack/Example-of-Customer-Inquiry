using Example.WebApi.DataAccess.IRepositories;
using Example.WebApi.DataAccess.Model.Database.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.WebApi.DataAccess.Repositories
{
    public class MasterCustomerRepository : RepositoryBase, IMasterCustomerRepository
    {
        public MasterCustomerRepository(ApplicationDbContext context) : base(context) { }

        public void Create(Customers data)
        {
            if (data == null) throw new Exception("A customer information cannot be null");

            _context.Customers.Add(data);
        }

        public void Update(Customers data)
        {
            if (data == null) throw new Exception("A customer information cannot be null");

            var info = FindOneOfCustomerById(data.customerID);
            if (info != null)
            {
                info.customerName = data.customerName;
                info.mobile = data.mobile;
                info.status = data.status;

                _context.Entry(info).State = EntityState.Modified;
            }
            else throw new Exception("Customer Not Found");
        }

        private Customers FindOneOfCustomerById(long id)
        {
            return _context.Customers
                           .Where(x => x.customerID.Equals(id))
                           .Select(x => x)
                           .FirstOrDefault();
        }

        private Customers FindOneOfCustomerByEmail(string email)
        {
            return _context.Customers
                           .Where(x => x.email.Equals(email))
                           .Select(x => x)
                           .FirstOrDefault();
        }

        public Customers FindOneOfCustomer(long id, string email)
        {
            if (id > 0 && string.IsNullOrEmpty(email))
            {
                return FindOneOfCustomerById(id);
            }
            else if (id == 0 && !string.IsNullOrEmpty(email))
            {
                return FindOneOfCustomerByEmail(email);
            }
            else
            {
                return _context.Customers
                               .Where(x => x.customerID.Equals(id) && x.email.Equals(email))
                               .Select(x => x)
                               .FirstOrDefault();
            }
        }
    }
}
