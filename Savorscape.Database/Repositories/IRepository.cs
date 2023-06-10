using Savorscape.Database.Models;
using System.Linq.Expressions;

namespace Savorscape.Database.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity? GetByID(int id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        bool Delete(int id);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
