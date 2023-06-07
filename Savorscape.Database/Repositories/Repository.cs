using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Savorscape.Database.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly SavorscapeDbContext context;
        protected readonly DbSet<TEntity> entities;

        public Repository(SavorscapeDbContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public virtual TEntity? GetByID(int id)
        {
            return entities.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            entities.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = GetByID(id);

            if (entity == null)
                return;

            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                entities.Attach(entity);
            }

            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
