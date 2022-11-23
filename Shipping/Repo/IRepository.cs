
using System.Linq.Expressions;

namespace Shipping.repo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(dynamic id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
       

    }
}
