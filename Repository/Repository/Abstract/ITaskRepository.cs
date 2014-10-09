using Repository.Concrete.Entities;
using System.Linq;

namespace Repository.Abstract
{
    public interface ITaskRepository : IGenericRepository<Task>
    {

        IQueryable<Task> GetAllByCarId(int carId);

        IQueryable<Task> GetAllByCustomerId(int customerId);
    }
}
