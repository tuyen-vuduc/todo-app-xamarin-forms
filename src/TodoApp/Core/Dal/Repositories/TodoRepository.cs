using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApp
{
    public class TodoRepository : Repository<TodoEntity>
    {
        public TodoRepository(TodosDbContext dbContext)
            : base(dbContext)
        {

        }

        public override async Task<IEnumerable<TodoEntity>> GetAllAsync(
            Expression<Func<TodoEntity, bool>> filter)
        {
            var query = dbContext.Todos.Where(filter);
            var result = await query.ToListAsync();
            return result;
        }
    }
}
