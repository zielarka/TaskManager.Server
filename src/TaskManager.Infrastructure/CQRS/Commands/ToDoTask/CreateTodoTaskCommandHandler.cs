using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Domain;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class CreateTodoTaskCommandHandler : IRequestHandler
        <CreateTodoTaskCommand, Unit>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public CreateTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<Unit> Handle(CreateTodoTaskCommand command, CancellationToken cancellationToken)
        {
            var task = new TodoTask(command.Id, command.Title, command.Description, command.DueDate);
            await _toDoTaskRepository.AddAsync(task, cancellationToken);
            return await Task.FromResult(Unit.Value);
        }
    }
}
