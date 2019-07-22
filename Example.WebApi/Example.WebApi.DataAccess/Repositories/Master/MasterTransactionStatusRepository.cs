using Example.WebApi.DataAccess.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.WebApi.DataAccess.Repositories.Master
{
    public class MasterTransactionStatusRepository : RepositoryBase, IMasterTransactionStatusRepository
    {
        public MasterTransactionStatusRepository(ApplicationDbContext context) : base(context) { }

        public string FindStatusDescription(string code)
        {
            return _context.TransactionStatuses
                                       .Where(x => x.code.Equals(code))
                                       .Select(x => x.description)
                                       .FirstOrDefault();
        }
    }
}
