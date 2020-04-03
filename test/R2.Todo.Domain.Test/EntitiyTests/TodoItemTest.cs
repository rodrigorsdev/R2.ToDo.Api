using R2.Todo.Domain.Entities;
using System;
using Xunit;

namespace R2.Todo.Domain.Test.EntitiyTests
{
    public class TodoItemTest
    {
        [Fact]
        public void TodoItemDoneMustBeFalseAtCreate()
        {
            var Todo = new TodoItem("title", "usermustbegoogle", DateTime.Now);
            Assert.False(Todo.Done);
        }
    }
}
