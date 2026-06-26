using ECommerce.Domain.Aggregates.Customer.ValueObjects;
using ECommerce.Domain.Aggregates.Order;
using ECommerce.Domain.Aggregates.Order.Enumeration;
using ECommerce.Domain.Aggregates.Order.ValueObjects;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.DbContextConfigurations;

public class OrderConfiguration: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new OrderId(value));

        builder.Property(x => x.CustomerId)
            .HasConversion(
                id => id.Value,
                value => new CustomerId(value));
        builder.Property(x => x.OrderStatus)
            .HasConversion(
                status => status.Id,
                id => Enumeration.FromValue<OrderStatus>(id));
        
       

        builder.Ignore(x => x.TotalPrice);
        builder.Ignore(x => x.OrderItems);
        builder.OwnsMany<OrderItem>("_orderItems", item =>
        {
            item.ToTable("OrderItems");

            item.WithOwner()
                .HasForeignKey("OrderId");

            item.HasKey(x => x.Id);

            item.Property(x => x.Id)
                .HasConversion(
                    id => id.Value,
                    value => new OrderItemId(value));

            item.Property(x => x.ProductId)
                .HasConversion(
                    id => id.Value,
                    value => new ProductId(value));

            item.Property(x => x.Quantity)
                .IsRequired();

            item.Property(x => x.UnitPrice)
                .HasPrecision(18, 2);

            item.Ignore(x => x.TotalPrice);
        });

        builder.Navigation("_orderItems")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}