namespace ECommerce.Application.Abstractions.Contracts;

public interface IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}