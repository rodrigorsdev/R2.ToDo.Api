using Microsoft.EntityFrameworkCore;
using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Queries;
using R2.Todo.Domain.Repositories;
using R2.Todo.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace R2.Todo.Infra.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(TodoItem todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public TodoItem GetById(Guid id, string user)
        {
            return _context
                .Todos
                .FirstOrDefault(x => x.Id == id && x.User == user);
        }

        public void Update(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return _context.Todos
               .AsNoTracking()
               .Where(TodoQueries.GetAll(user))
               .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllDone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetAllUndone(user))
                .OrderBy(x => x.Date);
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return _context.Todos
                .AsNoTracking()
                .Where(TodoQueries.GetByPeriod(user, date, done))
                .OrderBy(x => x.Date);
        }
    }
}
