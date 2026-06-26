using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Core;
using ECommerce.Shared;
using FluentAssertions;

namespace ECommerceApp.UnitTest.CategoryTests;

public class CategoryIdTests
{
    

    [Fact]
    public void Constructor_Should_Set_Value()
    {
          
        var id =CategoryFaker.CategoryId();
        var categoryId=new CategoryId(id);
        categoryId.Value.Should().Be(id);
    }

    [Fact]
    public void Constructor_Should_Throw_DomainException_When_Value_Is_Empty()
    {
        // Act
        var action = () => new CategoryId(Guid.Empty);

        // Assert
        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Two_CategoryIds_With_Same_Value_Should_Be_Equal()
    {
        // Arrange
        var value = CategoryFaker.CategoryId();

        var first = new CategoryId(value);
        var second = new CategoryId(value);

        // Assert
        first.Should().Be(second);
    }
}