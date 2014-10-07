using Repository.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        IQueryable<Car> GetAllByCustomerId(int customerId);

    }
}
