using MediatR;
using System;

namespace TaskManager.Infrastructure.CQRS.Commands.ToDoTask
{
    public class CreateTodoTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int Status { get; set; }
    }
}
