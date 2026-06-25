using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Domain.Core;
using MediatR;

namespace ECommerce.Infrastructure.Services;

public class MediatrDomainEventDispatcher(IPublisher publisher) : IDomainEventDispatcher
{
    public async Task DispatchAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
    {
        var notificationType = typeof(IDomainEvent).MakeGenericType(domainEvent.GetType());
        var notification = Activator.CreateInstance(notificationType, domainEvent);

        if (notification is INotification mediatrNotification)
        {
            await publisher.Publish(mediatrNotification, cancellationToken);
        }
    }
}