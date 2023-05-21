using EidosTestWork.Application.Helpers;
using MediatR;

namespace EidosTestWork.Application.Abstractions.Messaging;

public interface IAppRequestHandler<TCommand> : IRequestHandler<TCommand,Result> 
    where TCommand : IAppRequest
{
}

public interface IAppRequestHandler<TCommand,TResponse> : 
    IRequestHandler<TCommand,Result<TResponse>> 
    where TCommand : IAppRequest<TResponse>
{
}