using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using R2.Todo.Domain.Commands;
using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Handlers;
using R2.Todo.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace R2.Todo.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
            [FromServices]ITodoRepository repository
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            return repository.GetAll(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndone(
            [FromServices]ITodoRepository repository
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            return repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
           [FromServices]ITodoRepository repository
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date,
                true);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
          [FromServices]ITodoRepository repository
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForTomorrow(
         [FromServices]ITodoRepository repository
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            return repository.GetByPeriod(
                user,
                DateTime.Now.Date.AddDays(1),
                false);
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices]TodoHandler handler
        )
        {
            string user = User.Claims.FirstOrDefault(a => a.Type == "user_id")?.Value;
            command.User = user;
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Update(
            [FromBody] UpdateTodoCommand command,
            [FromServices]TodoHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices]TodoHandler handler
        )
        {
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
             [FromBody] MarkTodoAsUndoneCommand command,
             [FromServices]TodoHandler handler
         )
        {
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}