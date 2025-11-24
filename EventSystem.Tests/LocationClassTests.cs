using EventSystem.Classes;

namespace EventSystem.Tests;

public class LocationClassTests
{
    private Location _location = new Location(10000, "Al. Wilanowska 12", new List<Event>());

    [Fact]
    public void LocationCreationTest()
    {
        Assert.Equal(10000, _location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _location.Address);
        Assert.Equal(new List<Event>(), _location.EventsAssigned);
    }

    [Fact]
    public void LocationCapacitySmallerThenOneTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Location(0, "Al. Wilanowska 12", new List<Event>()));
        Assert.Equal("Capacity cannot be less than 1.", ex.Message);
    }

    [Fact]
    public void LocationAddressNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Location(10000, "", new List<Event>()));
        Assert.Equal("Address cannot be empty.", ex.Message);
    }
}