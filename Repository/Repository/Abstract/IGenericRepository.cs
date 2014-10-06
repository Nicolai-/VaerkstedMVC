using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Repository.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(int? id);

        IQueryable<TEntity> GetAll();

        void Edit(TEntity entity);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Dispose();
    }
}