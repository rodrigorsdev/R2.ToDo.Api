using R2.Todo.Domain.Commands.Contracts;

namespace R2.Todo.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
