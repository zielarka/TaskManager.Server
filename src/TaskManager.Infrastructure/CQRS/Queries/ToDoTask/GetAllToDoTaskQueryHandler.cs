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
    public class GetAllToDoTaskQueryHandler : IRequestHandlerWrapper<GetAllToDoTaskQuery, IEnumerable<TodoTaskDto>>
    {
        private readonly IToDoTaskRepository _toDoTaskRepository;
        private readonly IMapper _mapper;

        public GetAllToDoTaskQueryHandler(IToDoTaskRepository toDoTaskRepository, IMapper mapper)
        {
            _toDoTaskRepository = toDoTaskRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<IEnumerable<TodoTaskDto>>> Handle(GetAllToDoTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = _mapper.Map<IEnumerable<TodoTaskDto>>(await _toDoTaskRepository.GetAllAsync(cancellationToken));

            if (tasks != null)
                return ServiceResult.Success(tasks);
            else
                return ServiceResult.Failed<IEnumerable<TodoTaskDto>>(ServiceError.ForbiddenError);
        }
    }
}
