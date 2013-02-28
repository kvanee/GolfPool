using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GolfPool.DB
{
    public class Repository : IRepository
    {
        private readonly GolfPoolEntities entities;

        public Repository(GolfPoolEntities entities)
        {
            this.entities = entities;
        }

        public GolfPoolEntities Entities
        {
            get { return entities; }
        }

        public IQueryable<T> All<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            IQueryable<T> query = entities.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public T Find<T>(int id) where T : class
        {
            return entities.Set<T>().Find(id);
        }

        public void Insert<T>(T entity) where T : class
        {
            entities.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            entities.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(int id) where T : class
        {
            var objective = entities.Set<T>().Find(id);
            entities.Set<T>().Remove(objective);
        }

        public void Save()
        {
            entities.SaveChanges();
        }
    }
}