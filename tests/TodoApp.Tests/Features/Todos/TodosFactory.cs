using System;
using System.Collections.Generic;
using Bogus;

namespace TodoApp.Tests.Features.Todos
{
    public class TodosFactory
    {
        private static TodosFactory? todosFactory;

        public static TodosFactory Instance
        {
            get
            {
                if (todosFactory != null)
                {
                    return todosFactory;
                }

                todosFactory = new TodosFactory();

                return todosFactory;
            }
        }

        private readonly Faker<TodoEntity> faker;

        protected TodosFactory()
        {
            faker = new Faker<TodoEntity>();
            faker.RuleFor(x => x.Id, f => Guid.NewGuid());
            faker.RuleFor(x => x.Category, f => f.Commerce.Categories(10)[0]);
            faker.RuleFor(x => x.Title, f => f.Commerce.Product());
        }

        public IEnumerable<TodoEntity> GetTodos() => faker.Generate(100);
    }
}

