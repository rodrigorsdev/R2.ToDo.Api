using System;
using System.Collections.Generic;
using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Repositories;

namespace R2.Todo.Domain.Test.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem Todo)
        {
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            throw new NotImplementedException();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return new TodoItem("title", "userbygoogle", DateTime.Now);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem Todo)
        {
        }
    }
}
