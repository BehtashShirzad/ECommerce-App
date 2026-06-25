namespace ECommerce.Domain.Core;

public interface IAuditableEntity
{
  public  Guid CreatorId { get; set; }
  public  Guid? ModifierId { get; set; }
  public  DateTime CreatedAt { get; set; }
  public  DateTime? ModifiedAt { get; set; }
}