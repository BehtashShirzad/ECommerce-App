namespace ECommerce.Domain.Core;
public abstract class BaseEntity
{
}
public abstract class Entity<TId>:BaseEntity,IAuditableEntity
{
    public TId Id { get; protected set; } = default!;
    public DateTime CreatedAt { get;   set; } = DateTime.UtcNow;
    public Guid? ModifierId { get ;set; }
    public DateTime? ModifiedAt { get ;set; }
    public Guid CreatorId { get ;set; }
    public override bool Equals(object? obj)
    {
        if (obj is not Entity<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
        => Equals(left, right);

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
        => !Equals(left, right);
}