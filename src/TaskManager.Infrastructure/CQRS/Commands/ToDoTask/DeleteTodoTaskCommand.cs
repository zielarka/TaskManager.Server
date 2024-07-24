using MediatR;
using System;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class DeleteTodoTaskCommand : IRequest<Unit>
    {
        public Guid taskId { get; set; }
    }
}
