using R2.Todo.Domain.Commands;
using R2.Todo.Domain.Commands.Contracts;
using R2.Todo.Domain.Entities;
using R2.Todo.Domain.Handlers.Contracts;
using R2.Todo.Domain.Repositories;

namespace R2.Todo.Domain.Handlers
{
    public class TodoHandler :
         IHandler<CreateTodoCommand>,
         IHandler<UpdateTodoCommand>,
         IHandler<MarkTodoAsDoneCommand>,
         IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _TodoRepository;

        public TodoHandler(ITodoRepository TodoRepository)
        {
            _TodoRepository = TodoRepository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo náo está certo!",
                    command.Notifications);

            var entity = new TodoItem(
                command.Title,
                command.User,
                command.Date);

            _TodoRepository.Create(entity);

            return new GenericCommandResult(
                true,
                "Tarefa salva!",
                entity);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo náo está certo!",
                    command.Notifications);

            TodoItem entity = _TodoRepository.GetById(command.Id, command.User);

            entity.UpdateTitle(command.Title);

            _TodoRepository.Update(entity);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada!",
                entity);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo náo está certo!",
                    command.Notifications);

            TodoItem entity = _TodoRepository.GetById(command.Id, command.User);

            entity.MarkAsDone();

            _TodoRepository.Update(entity);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada!",
                entity);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(
                    false,
                    "Algo náo está certo!",
                    command.Notifications);

            TodoItem entity = _TodoRepository.GetById(command.Id, command.User);

            entity.MarkAsUndone();

            _TodoRepository.Update(entity);

            return new GenericCommandResult(
                true,
                "Tarefa atualizada!",
                entity);
        }
    }
}