using TaskManager.Infrastructure.Models;
using MediatR;

namespace TaskManager.Infrastructure.Service
{
    public interface IRequestWrapper<T> : IRequest<ServiceResult<T>> { }

    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ServiceResult<TOut>> where TIn : IRequestWrapper<TOut> { }
}

