using Example.WebApi.DataAccess.Model.Database.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Example.WebApi.DataAccess
{
    public class Seed
    {
        private ModelBuilder _modelBuilder;

        public Seed(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void InitialCustomerStatus()
        {
            List<CustomerStatus> ins = new List<CustomerStatus>()
            {
                new CustomerStatus
                {
                    code = "A",
                    description = "Active"
                },
                new CustomerStatus
                {
                    code = "L",
                    description = "Locked"
                },
                new CustomerStatus
                {
                    code = "S",
                    description = "Suspend"
                },
                new CustomerStatus
                {
                    code = "C",
                    description = "Cancel"
                },
                new CustomerStatus
                {
                    code = "D",
                    description = "De-Active"
                }
            };

            _modelBuilder.Entity<CustomerStatus>().HasData(ins.ToArray());
        }

        public void InitialTransactionsStatus()
        {
            List<TransactionsStatus> ins = new List<TransactionsStatus>()
            {
                new TransactionsStatus
                {
                    code = "S",
                    description = "Success"
                },
                 new TransactionsStatus
                {
                    code = "W",
                    description = "Waiting"
                },
                 new TransactionsStatus
                {
                    code = "C",
                    description = "Canceled"
                },
                new TransactionsStatus
                {
                    code = "F",
                    description = "Failed"
                }
            };

            _modelBuilder.Entity<TransactionsStatus>().HasData(ins.ToArray());
        }
    }
}
