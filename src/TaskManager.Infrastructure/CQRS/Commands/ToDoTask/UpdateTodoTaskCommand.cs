using MediatR;
using System;
using TaskManager.Core.Enums;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class UpdateTodoTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatusEnum Status { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
