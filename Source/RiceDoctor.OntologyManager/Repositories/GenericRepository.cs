using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RiceDoctor.OntologyManager.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<TEntity> objects = _dbSet.Where(expression).AsEnumerable();
            foreach (TEntity obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }
    }
}