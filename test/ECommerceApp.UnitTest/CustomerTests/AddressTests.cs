using Bogus;
using ECommerce.Domain.Aggregates.Customer.ValueObjects;
using ECommerce.Domain.Core;
using FluentAssertions;

namespace ECommerceApp.UnitTest.CustomerTests;

public class AddressTests
{
    private readonly Faker _faker = new();

    [Fact]
    public void Create_Should_Create_Address_When_Data_Is_Valid()
    {
        // Arrange
        var line = _faker.Address.StreetAddress();
        var zip = _faker.Address.ZipCode();
        var city = _faker.Address.City();
        var state = _faker.Address.State();
        var country = _faker.Address.Country();

        // Act
        var address = Address.Create(line, zip, city, state, country);

        // Assert
        address.AddressLine1.Should().Be(line);
        address.ZipCode.Should().Be(zip);
        address.City.Should().Be(city);
        address.State.Should().Be(state);
        address.Country.Should().Be(country);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Create_Should_Throw_DomainException_When_AddressLine_Is_Invalid(string? value)
    {
        Action action = () => Address.Create(
            value!,
            _faker.Address.ZipCode(),
            _faker.Address.City(),
            _faker.Address.State(),
            _faker.Address.Country());

        action.Should().Throw<DomainException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Create_Should_Throw_DomainException_When_ZipCode_Is_Invalid(string? value)
    {
        Action action = () => Address.Create(
            _faker.Address.StreetAddress(),
            value!,
            _faker.Address.City(),
            _faker.Address.State(),
            _faker.Address.Country());

        action.Should().Throw<DomainException>();
    }

    [Fact]
    public void Two_Addresses_With_Same_Values_Should_Be_Equal()
    {
        // Arrange
        var line = _faker.Address.StreetAddress();
        var zip = _faker.Address.ZipCode();
        var city = _faker.Address.City();
        var state = _faker.Address.State();
        var country = _faker.Address.Country();

        var first = Address.Create(line, zip, city, state, country);
        var second = Address.Create(line, zip, city, state, country);

        // Assert
        first.Should().Be(second);
    }

    [Fact]
    public void Two_Addresses_With_Different_Values_Should_Not_Be_Equal()
    {
        var first = Address.Create(
            _faker.Address.StreetAddress(),
            _faker.Address.ZipCode(),
            _faker.Address.City(),
            _faker.Address.State(),
            _faker.Address.Country());

        var second = Address.Create(
            _faker.Address.StreetAddress(),
            _faker.Address.ZipCode(),
            _faker.Address.City(),
            _faker.Address.State(),
            _faker.Address.Country());

        first.Should().NotBe(second);
    }
}