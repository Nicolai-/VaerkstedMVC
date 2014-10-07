namespace Repository.Migrations
{
    using Repository.Concrete.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Concrete.VaerkstedContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Repository.Concrete.VaerkstedContext";
        }

        protected override void Seed(Repository.Concrete.VaerkstedContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Customers.AddOrUpdate(
              c => c.Name,
                new Customer { Id = 1, Name = "Jørgen Hansen", Company = "Jørgen Hansen Biler", Phone = 75467589 },
                new Customer { Id = 2, Name = "Klaus Jensen", Phone = 55446677 },
                new Customer { Id = 3, Name = "Jakob Jensen", Phone = 33333333 }
            );

            context.Cars.AddOrUpdate(
                c => c.Model,
                new Car { Id = 1, CustomerId = 2, Manufacturer = "Kia", Model = "Picanto", PlateNumber = "ZK23346", ChassisNumber = "HH77JHJ999NJ", Year = 2014 },
                new Car { Id = 2, CustomerId = 1, Manufacturer = "Suzuki", Model = "Alto", PlateNumber = "AM22398", ChassisNumber = "GFFFF779809D", Year = 2010 }
            );
        }
    }
}
