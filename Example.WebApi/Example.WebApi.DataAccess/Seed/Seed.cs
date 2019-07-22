using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.WebApi.DataAccess.Seed
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
