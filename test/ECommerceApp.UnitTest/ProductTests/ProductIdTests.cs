using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;
using FluentAssertions;

namespace ECommerceApp.UnitTest.ProductTests;

public class ProductIdTests
{
    private readonly ProductFixture _fixture = new();

    [Fact]
    public void Constructor_Should_Create_ProductId_When_Value_Is_Valid()
    {
        // Act
        var id = _fixture.ProductId;
        var productId = new ProductId(id);

        // Assert
        productId.Should().NotBeNull();
        productId.Value.Should().Be(id);
    }

    [Fact]
    public void Constructor_Should_Throw_DomainException_When_Value_Is_Empty()
    {
        // Act
        Action action = () => new ProductId(Guid.Empty);

        // Assert
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Two_ProductIds_With_Same_Value_Should_Be_Equal()
    {
        // Arrange
        var value = _fixture.ProductId;

        var first = new ProductId(value);
        var second = new ProductId(value);

        // Assert
        first.Should().Be(second);
    }

    [Fact]
    public void Two_ProductIds_With_Different_Values_Should_Not_Be_Equal()
    {
        // Arrange
        var first = new ProductId(_fixture.ProductId);
        var second = new ProductId(Guid.NewGuid());

        // Assert
        first.Should().NotBe(second);
    }
}