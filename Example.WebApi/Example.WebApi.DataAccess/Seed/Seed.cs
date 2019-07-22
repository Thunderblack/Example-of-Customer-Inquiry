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
    }
}
