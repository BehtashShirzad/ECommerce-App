using MediatR;

namespace ECommerce.Application.Abstractions.Contracts;
public interface ITransactionalCommand
{
}

public interface ITransactionalVoidCommand:IRequest,ITransactionalCommand { }
public interface ITransactionalCommand<TResponse> : IRequest<TResponse>,ITransactionalCommand{ }