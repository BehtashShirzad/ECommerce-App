using Ardalis.GuardClauses;
using ECommerce.Domain.Aggregates.Category;
using ECommerce.Domain.Aggregates.Product.DomainEvents;
using ECommerce.Domain.Aggregates.Product.ValueObjects;
using ECommerce.Domain.Core;
using ECommerce.Domain.GuardExtensions;
using ECommerce.Shared;

namespace ECommerce.Domain.Aggregates.Product;

public class Product:AggregateRoot<ProductId>
{
    public decimal Price { get;private  set; }//Todo: Better To change VlaueObject price
    public string Name { get; private set; } 
    public string? Description { get;private set; }
    public string Slug { get;private set; }
    public CategoryId  CategoryId { get;private  set; }
    public Category.Category Category { get;private set; }
    public string? ImageUrl { get;private set; } //Todo: Better To change VlaueObject Image
    const long MinimumPrice = 1;
    const long MaximumPrice = long.MaxValue;
    private Product(CategoryId categoryId, string name, decimal price,string description, string slug )
    {
        Price = price;
        Name = name;
        Description = description;
        Slug = slug;
       
        CategoryId = categoryId;
    }
    public static Product Create(CategoryId categoryId, string name , decimal price,string description,string slug  )
    {
        Guard.Against.Null(categoryId, ProductErrors.InvalidCategory);
        Guard.Against.NullOrEmpty(name,ProductErrors.InvalidProductName);
         
        Guard.Against.InvalidNumerRange(price,MinimumPrice,MaximumPrice,ProductErrors.InvalidProductPrice);
        var product = new Product(categoryId,name, price,description, slug  )
            {Id =new ProductId(IdGenerator.New())};
        
        return  product;
    }

    public void Update(CategoryId? categoryId,
        string? name, decimal? price, string? description, string? slug,string? imageUrl)
    {
        if (!string.IsNullOrWhiteSpace(name))
            Name = name;
        if (!string.IsNullOrWhiteSpace(description))
            Description = description;
        if (!string.IsNullOrWhiteSpace(slug))
            Slug = slug;
        if (!string.IsNullOrWhiteSpace(imageUrl))
            ImageUrl = imageUrl;
        if (categoryId is not null )
            CategoryId = categoryId;
        AddDomainEvent(new ProductUpdatedDomainEvent(Id));
    }
    public void SetImage(string imageUrl)
    {
        ImageUrl = imageUrl;
    }
}