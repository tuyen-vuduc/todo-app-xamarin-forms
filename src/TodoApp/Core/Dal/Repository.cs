using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApp
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly TodosDbContext dbContext;

        public Repository(TodosDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await dbContext.FindAsync<T>(id);

            if (entity == null) return false;

            entity.IsDeleted = !entity.IsDeleted;
            entity.DeletedAt = DateTime.Now;

            var changeCount = await dbContext.SaveChangesAsync();

            return changeCount > 0;
        }

        public async Task<T> GetAsync(Guid id)
        {
            var entity = await dbContext.FindAsync<T>(id);

            if (entity == null) return default(T);

            return entity;
        }

        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var query = dbContext.Set<T>().Where(filter);
            return query.ToListAsync()
                .ContinueWith(t => (IEnumerable<T>)t.Result);
        }

        public async Task<Guid> InsertAsync(T entity)
        {
            var id = Guid.NewGuid();
            entity.Id = id;

            entity.CreatedAt = DateTime.Now;
            entity.LastModified = DateTime.Now;
            entity.IsDeleted = false;
            entity.DeletedAt = null;

            await dbContext.AddAsync(entity);

            var rowCount = await dbContext.SaveChangesAsync();

            return rowCount > 0 ? id : Guid.Empty;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            entity.LastModified = DateTime.Now;
            entity.IsDeleted = false;
            entity.DeletedAt = null;

            dbContext.Update(entity);

            var rowCount = await dbContext.SaveChangesAsync();

            return rowCount > 0;
        }
    }
}
