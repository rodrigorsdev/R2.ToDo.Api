using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace R2.Todo.Domain.Test.QueryTests
{
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "usuarioB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "usuarioB", DateTime.Now));
        }

        [Fact]
        public void GetAllByUserMustBeResultLengthTwo()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("usuarioB"));
            Assert.Equal(2, result.Count());
        }
    }
}