using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product;
using ECommerce.Domain.Core;
using FluentAssertions;

namespace ECommerceApp.UnitTest.ProductTests;

public class ProductTests
{
    private readonly ProductFixture _fixture = new();

    [Fact]
    public void Create_Should_Create_Product_When_Data_Is_Valid()
    {
        var categoryId= _fixture.CategoryId;
         var productName =  _fixture.Name;
         var price =  _fixture.Price;
         var des =  _fixture.Description;
         var slug =  _fixture.Slug;
         var img =  _fixture.ImageUrl;
        
        // Act
        var product = Product.Create(
            categoryId,
            productName,
            price,
            des,
            slug
            );

        // Assert
        product.Should().NotBeNull();
        product.Id.Value.Should().NotBe(Guid.Empty);
        product.CategoryId.Should().Be(categoryId);
        product.Name.Should().Be(productName);
        product.Price.Should().Be(price);
        product.Description.Should().Be(des);
        product.Slug.Should().Be(slug);
        
    }

    [Fact]
    public void Create_Should_Throw_DomainException_When_Category_Is_Null()
    {
        // Act
        Action action = () => Product.Create(
            null!,
            _fixture.Name,
            _fixture.Price,
            _fixture.Description,
            _fixture.Slug);

        // Assert
        action.Should().Throw<DomainException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Create_Should_Throw_DomainException_When_Name_Is_Invalid(string? name)
    {
        // Act
        Action action = () => Product.Create(
            _fixture.CategoryId,
            name!,
            _fixture.Price,
            _fixture.Description,
            _fixture.Slug);

        // Assert
        action.Should().Throw<DomainException>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Create_Should_Throw_DomainException_When_Price_Is_Invalid(decimal price)
    {
        // Act
        Action action = () => Product.Create(
            _fixture.CategoryId,
            _fixture.Name,
            price,
            _fixture.Description,
            _fixture.Slug);

        // Assert
        action.Should().Throw<DomainException>();
    }



    [Fact]
    public void Create_Should_Generate_Unique_Id()
    {
        // Act
        var first = Product.Create(
            _fixture.CategoryId,
            _fixture.Name,
            _fixture.Price,
            _fixture.Description,
            _fixture.Slug);

        var second = Product.Create(
            _fixture.CategoryId,
            _fixture.Name,
            _fixture.Price,
            _fixture.Description,
            _fixture.Slug);

        // Assert
        first.Id.Value.Should().NotBe(second.Id.Value);
    }
}