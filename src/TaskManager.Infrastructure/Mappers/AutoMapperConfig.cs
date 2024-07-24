using AutoMapper;
using TaskManager.Core.Domain;
using TaskManager.Infrastructure.DTO;

namespace TaskManager.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TodoTask, TodoTaskDto>();
            })
            .CreateMapper();
    }
}
