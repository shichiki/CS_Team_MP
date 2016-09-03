using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RiceDoctor.OntologyManager.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(Expression<Func<TEntity, bool>> expression);

        TEntity Get(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression);
    }
}