using EventSystem.Classes;

namespace EventSystem.Tests;

public class AddressClassTests
{
    private Address _address = new Address("Poland", "Warsaw",
        "Al. Wilanowska 12", "125", "02-123", new List<Staff>());

    [Fact]
    public void AddressCreationTest()
    {
        Assert.Equal("Poland", _address.Country);
        Assert.Equal("Warsaw", _address.City);
        Assert.Equal("Al. Wilanowska 12", _address.Street);
        Assert.Equal("125", _address.AppNumber);
        Assert.Equal("02-123", _address.Index);
        Assert.Equal(new List<Staff>(), _address.Staff);
    }
    
    [Fact]
    public void AddressCountryNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>()));
        Assert.Equal("Country cannot be empty.", ex.Message);
    }

    [Fact]
    public void AddressCityNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>())); 
        Assert.Equal("City cannot be empty.", ex.Message);
    }

    [Fact]
    public void AddressStreetNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "", "125", "02-123", new List<Staff>())); 
        Assert.Equal("Street cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void AddressAppNumberNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "", "02-123", new List<Staff>())); 
        Assert.Equal("App number cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void AddressIndexNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "", new List<Staff>())); 
        Assert.Equal("Index cannot be empty.", ex.Message);
    }
}