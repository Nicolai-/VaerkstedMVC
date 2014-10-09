using Repository.Concrete.Entities;
using System.Linq;

namespace Repository.Abstract
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        IQueryable<Car> GetAllByCustomerId(int customerId);

    }
}
