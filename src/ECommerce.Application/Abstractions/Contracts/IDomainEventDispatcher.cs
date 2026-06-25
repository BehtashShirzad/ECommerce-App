using ECommerce.Domain.Core;

namespace ECommerce.Application.Abstractions.Contracts;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
}