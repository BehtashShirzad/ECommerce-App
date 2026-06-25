using ECommerce.Domain.Core;

namespace ECommerce.Application.Abstractions.Contracts;

public interface IDomainEventBus
{
    Task PublishAsync<T>(
        T domainEvent,
        CancellationToken cancellationToken = default)
        where T : IDomainEvent;
}
