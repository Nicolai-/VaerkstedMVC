using Repository.Abstract;
using Repository.Concrete.Entities;
using System.Data.Entity;
using System.Linq;

namespace Repository.Concrete
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository()
        {
        }

        public TaskRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
        public IQueryable<Task> GetAllByCarId(int carId)
        {
            return DbSet.Where(task => task.CarId == carId);
        }

        public IQueryable<Task> GetAllByCustomerId(int customerId)
        {
            return DbSet.Where(task => task.Car.Customer.Id == customerId);           
        }
    }
}
