using Bogus;
using ECommerce.Domain.Aggregates.Category;
using ECommerce.Shared;

namespace ECommerceApp.UnitTest.CategoryTests;

public static class CategoryFaker
{
    private static readonly Faker Faker = new();

    public static string Name() => Faker.Commerce.Department();

    public static string Description() => Faker.Lorem.Sentence();

    public static bool IsActive() => Faker.Random.Bool();
    public static Guid CategoryId() => IdGenerator.New() ;
}