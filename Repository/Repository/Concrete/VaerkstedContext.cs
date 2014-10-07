using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class VaerkstedContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
