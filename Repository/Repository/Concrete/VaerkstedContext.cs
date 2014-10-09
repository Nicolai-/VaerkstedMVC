using Repository.Concrete.Entities;
using System.Data.Entity;

namespace Repository.Concrete
{
    public class VaerkstedContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Task> Tasks { get; set; }
    }
}
