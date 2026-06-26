using MediatR;

namespace ECommerce.Application.Abstractions.Contracts;

public interface ICommand :IRequest{ }

public interface ICommand<TResponse> : IRequest<TResponse>{ }