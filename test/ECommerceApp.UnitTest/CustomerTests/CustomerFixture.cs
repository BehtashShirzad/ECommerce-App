using Bogus;
using ECommerce.Domain.Aggregates.Customer.ValueObjects;

namespace ECommerceApp.UnitTest.CustomerTests;

public class CustomerFixture
{
    private readonly Faker _faker = new();

    public string FirstName => _faker.Name.FirstName();

    public string LastName => _faker.Name.LastName();

    public string PhoneNumber => _faker.Phone.PhoneNumber("09#########");

    public Guid IdentityUserId => _faker.Random.Guid();

    public Address Address => Address.Create(
        _faker.Address.StreetAddress(),
        _faker.Address.ZipCode(),
        _faker.Address.City(),
        _faker.Address.State(),
        _faker.Address.Country());
}