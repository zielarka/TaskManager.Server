using System;
using TaskManager.Infrastructure.DTO;
using TaskManager.Infrastructure.Service;

namespace TaskManager.Infrastructure.CQRS.Queries.ToDoTask
{
    public class GetTodoTaskByIdQuery : IRequestWrapper<TodoTaskDto>
    {
        public Guid taskId { get; set; }
    }
}
