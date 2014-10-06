using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;

        private readonly DbContext _dbContext;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public GenericRepository()
        {
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int? id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
