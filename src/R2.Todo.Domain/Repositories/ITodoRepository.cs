using R2.Todo.Domain.Entities;
using System;

namespace R2.Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem Todo);
        void Update(TodoItem Todo);
        TodoItem GetById(Guid id, string user);
    }
}