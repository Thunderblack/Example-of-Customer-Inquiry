using Example.WebApi.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.WebApi.DataAccess.Repositories
{
    public class MasterCustomerStatusRepository : RepositoryBase, IMasterCustomerStatusRepository
    {
        public MasterCustomerStatusRepository(ApplicationDbContext context) : base(context) { }

        public string FindStatusDescription(string code)
        {
            return _context.CustomerStatuses
                           .Where(x => x.code.Equals(code))
                           .Select(x => x.description)
                           .FirstOrDefault();
        }
    }
}
