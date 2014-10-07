using Repository.Abstract;
using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository()
        {
        }

        public CarRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
        public IQueryable<Car> GetAllByCustomerId(int customerId)
        {
            return DbSet.Where(car => car.CustomerId == customerId);
        }
    }
}
