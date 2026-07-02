using ECommerce.Domain.Aggregates.Cart;
using Microsoft.Extensions.Caching.Hybrid;
namespace ECommerce.Infrastructure.Repositories;

public class CartRepository(HybridCache hybridCache):ICartRepository
{
    private const string CartCacheKey = "Cart_{0}";

    private readonly HybridCacheEntryOptions  _options=new HybridCacheEntryOptions()
    {
        Expiration = TimeSpan.FromHours(3),
        LocalCacheExpiration = TimeSpan.FromMinutes(30)
    };
    public async ValueTask AddAsync(CartAggregate entity, CancellationToken cancellationToken = default)
    {
        var key = string.Format(CartCacheKey, entity.CustomerId);
         await  hybridCache.SetAsync(key,entity,_options,cancellationToken:cancellationToken);
    }

    public void RemoveAsync(CartAggregate entity)
    {
         
    }

    public async Task<CartAggregate?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var key = string.Format(CartCacheKey, userId);
        return await hybridCache.GetOrCreateAsync(
            key,
            _ => ValueTask.FromResult<CartAggregate?>(null),_options,
            cancellationToken: cancellationToken);
    }
}