using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskManager.Core.Repositories;
using TaskManager.Infrastructure.DTO;
using TaskManager.Infrastructure.Models;
using TaskManager.Infrastructure.Service;

namespace TaskManager.Infrastructure.CQRS.Queries.ToDoTask
{
    public class GetTodoTaskByIdQueryHandler : IRequestHandlerWrapper<GetTodoTaskByIdQuery, TodoTaskDto>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;

        public GetTodoTaskByIdQueryHandler(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<TodoTaskDto>> Handle(GetTodoTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskDto = _mapper.Map<TodoTaskDto>(await _toDoTaskRepository.GetByIdAsync(request.taskId, cancellationToken));
            if (taskDto != null)
                return ServiceResult.Success(taskDto);
            else
                return ServiceResult.Failed<TodoTaskDto>(ServiceError.ForbiddenError);
        }
    }
}
