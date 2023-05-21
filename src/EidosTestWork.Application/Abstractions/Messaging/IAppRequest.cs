using EidosTestWork.Application.Helpers;
using MediatR;

namespace EidosTestWork.Application.Abstractions.Messaging;

public interface IAppRequest : IRequest<Result>
{
}

public interface IAppRequest<TResponse> : IRequest<Result<TResponse>>
{
}