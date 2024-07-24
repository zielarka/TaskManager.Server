﻿using MediatR;

namespace TaskManager.Infrastructure.CQRS.Queries
{
    public interface IQueryHandler<in TQuery, TResult> :
        IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    { }
}

