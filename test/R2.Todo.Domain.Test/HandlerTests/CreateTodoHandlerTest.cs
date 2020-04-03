using R2.Todo.Domain.Commands;
using R2.Todo.Domain.Handlers;
using R2.Todo.Domain.Repositories;
using R2.Todo.Domain.Test.Repositories;
using System;
using Xunit;

namespace R2.Todo.Domain.Test.HandlerTests
{
    public class CreateTodoHandlerTest
    {
        private ITodoRepository _TodoRepository;
        private TodoHandler _handler;

        public CreateTodoHandlerTest()
        {
            _TodoRepository = new FakeTodoRepository();
            _handler = new TodoHandler(_TodoRepository);
        }

        [Fact]
        public void CreateTodoCommandInvalid()
        {
            var command = new CreateTodoCommand("", DateTime.Now, "");
            var result = (GenericCommandResult)_handler.Handle(command);
            Assert.False(result.Success);
        }

        [Fact]
        public void CreateTodoCommandValid()
        {
            var command = new CreateTodoCommand("title", DateTime.Now, "userbygoogle");
            var result = (GenericCommandResult)_handler.Handle(command);
            Assert.True(result.Success);
        }
    }
}