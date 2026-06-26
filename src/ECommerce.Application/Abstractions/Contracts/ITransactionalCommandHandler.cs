using MediatR;

namespace ECommerce.Application.Abstractions.Contracts;

 
public interface ITransactionalCommandHandler<TRequest>:IRequestHandler<TRequest> where TRequest:ITransactionalCommand
{
        
}

public interface ITransactionalCommandHandler<TRequest,TResponse>
    :IRequestHandler<TRequest,TResponse> 
    where TRequest:ITransactionalCommand<TResponse>
{
        
}