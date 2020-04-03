using System;
using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Repositories;

namespace R2.Todo.Domain.Test.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem Todo)
        {
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("title", "userbygoogle", DateTime.Now);
        }

        public void Update(TodoItem Todo)
        {
        }
    }
}
