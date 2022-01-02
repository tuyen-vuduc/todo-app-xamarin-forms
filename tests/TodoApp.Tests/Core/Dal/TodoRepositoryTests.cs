using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Xunit;

namespace TodoApp.Tests.Core.Dal
{
    public class TodoRepositoryTests
    {
        [Fact]
        public async Task Add_ShouldInsertANewRecordIntoDb()
        {
            var dbContext = GetDbContext();

            var sut = new Repository<TodoEntity>(dbContext);
            var faker = new Faker<TodoEntity>();
            faker.RuleFor(x => x.Id, f => Guid.NewGuid());
            faker.RuleFor(x => x.Category, f => f.Commerce.Categories(10)[0]);
            faker.RuleFor(x => x.Title, f => f.Commerce.Product());

            var entity = faker.Generate(1)[0];

            await sut.InsertAsync(entity);

            Assert.Equal(1, dbContext.Todos.Count());

            var actual = dbContext.Todos.First();
            Assert.Equal(entity.Title, actual.Title);
        }


        [Fact]
        public async Task Update_ShouldInsertANewRecordIntoDb()
        {
            var dbContext = GetDbContext();

            var sut = new Repository<TodoEntity>(dbContext);
            var faker = new Faker<TodoEntity>();
            faker.RuleFor(x => x.Id, f => Guid.NewGuid());
            faker.RuleFor(x => x.Category, f => f.Commerce.Categories(10)[0]);
            faker.RuleFor(x => x.Title, f => f.Commerce.Product());

            var entity = faker.Generate(1)[0];

            await sut.InsertAsync(entity);

            var entity2 = faker.Generate(1)[0];
            entity.Title = entity2.Title;
            await sut.UpdateAsync(entity);

            Assert.Equal(1, dbContext.Todos.Count());

            var actual = dbContext.Todos.First();
            Assert.Equal(entity2.Title, actual.Title);
        }

        private TodosDbContext GetDbContext()
        {
            var filePath = $"{Environment.CurrentDirectory}/{nameof(Add_ShouldInsertANewRecordIntoDb)}.db3";
            File.Delete(filePath);
            var dbContext = new TodosDbContext($"Filename={filePath}");
            return dbContext;
        }
    }
}
