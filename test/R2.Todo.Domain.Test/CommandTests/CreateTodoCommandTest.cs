using R2.Todo.Domain.Commands;
using System;
using Xunit;

namespace R2.Todo.Domain.Test.CommandTests
{
    public class CreateTodoCommandTest
    {
        [Fact]
        public void CreateTodoCommandInvalidTitle()
        {
            var command = new CreateTodoCommand("ti", DateTime.Now, "userbygoogle");
            command.Validate();
            Assert.False(command.Valid);
        }

        [Fact]
        public void CreateTodoCommandInvalidUser()
        {
            var command = new CreateTodoCommand("title", DateTime.Now, "");
            command.Validate();
            Assert.False(command.Valid);
        }

        [Fact]
        public void CreateTodoCommandValid()
        {
            var command = new CreateTodoCommand("title", DateTime.Now, "userbygoogle");
            command.Validate();
            Assert.True(command.Valid);
        }
    }
}