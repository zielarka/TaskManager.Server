using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Repositories;
using TaskManager.Infrastructure.Extensions;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class UpdateTodoTaskCommandHandler : IRequestHandler
        <UpdateTodoTaskCommand, Unit>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;

        public UpdateTodoTaskCommandHandler(IToDoTaskRepository toDoTaskRepository)
        {
            _toDoTaskRepository = toDoTaskRepository;
        }

        public async Task<Unit> Handle(UpdateTodoTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _toDoTaskRepository.GetOrFailAsyncIfEmpty(request.Id, cancellationToken);
            task.UpdateTitle(request.Title);
            task.UpdateDueDate(request.DueDate);
            task.UpdateDescription(request.Description);
            task.UpdateStatus(request.Status);
            await _toDoTaskRepository.UpdateAsync(task, cancellationToken);

            return Unit.Value;
        }
    }
}
