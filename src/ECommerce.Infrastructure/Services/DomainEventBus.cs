using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Core;

namespace ECommerce.Infrastructure.Services;

public class DomainEventBus (IDomainEventDispatcher dispatcher): IDomainEventBus
{
    public async Task PublishAsync<T>(T message, CancellationToken cancellationToken = default)
        where T : IDomainEvent
         
    {
        await   dispatcher.DispatchAsync(message, cancellationToken);
      
    }
 
}