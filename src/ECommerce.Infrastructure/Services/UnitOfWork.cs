using ECommerce.Application.Abstractions.Contracts;
using ECommerce.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Services;

public class UnitOfWork(ApplicationDbContext  context):IUnitOfWork
{
    readonly  ApplicationDbContext  _context=context;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}