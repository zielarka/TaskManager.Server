using System.Collections.Generic;
using TaskManager.Infrastructure.DTO;
using TaskManager.Infrastructure.Service;

namespace TaskManager.Infrastructure.CQRS.Queries.ToDoTask
{
    public class GetAllToDoTaskQuery : IRequestWrapper<IEnumerable<TodoTaskDto>>
    {
    }
}
