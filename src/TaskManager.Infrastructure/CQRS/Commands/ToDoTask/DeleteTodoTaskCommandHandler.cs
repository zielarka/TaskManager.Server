using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Repositories;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class DeleteTodoTaskCommandHandler : IRequestHandler<DeleteTodoTaskCommand, Unit>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public DeleteTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }
        public async Task<Unit> Handle(DeleteTodoTaskCommand request, CancellationToken cancellationToken)
        {
            await _toDoTaskRepository.DeleteAsync(request.taskId, cancellationToken);
            return Unit.Value;
        }
    }
}
