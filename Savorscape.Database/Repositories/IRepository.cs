using System.Linq.Expressions;

namespace Savorscape.Database.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetByID(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
    }
}
