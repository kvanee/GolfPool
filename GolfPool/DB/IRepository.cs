using System;
using System.Linq;
using System.Linq.Expressions;

namespace GolfPool.DB
{
    public interface IRepository
    {
        IQueryable<T> All<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;
        T Find<T>(int id) where T : class;
        void Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(int id) where T : class;
        void Save();
        GolfPoolEntities Entities { get; }
    }
}