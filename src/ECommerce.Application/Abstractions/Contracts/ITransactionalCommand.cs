using MediatR;

namespace ECommerce.Application.Abstractions.Contracts;

public interface ITransactionalCommand:IRequest { }
public interface ITransactionalCommand<TResponse> : IRequest<TResponse>,ITransactionalCommand{ }