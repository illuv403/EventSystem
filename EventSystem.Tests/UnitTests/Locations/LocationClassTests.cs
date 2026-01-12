using EventSystem.Classes;

namespace EventSystem.Tests;

public class LocationClassTests
{
    private Location _location;

    private Event _event;
    public LocationClassTests()
    {
        _location = new(10000, "Al. Wilanowska 12", new List<Event>());
        _event = new("TestEvent", new DateTime(2026, 03, 01, 15, 00, 00), 
            new DateTime(2026, 03, 01, 19, 00, 00), 
            "Some event description", new List<Organizer>(){new Organizer("Johns", "Suron", 
                "jsuron@gmail.com", "+48956765432", new DateOnly(2005, 01, 01), 2978.69m, new List<Staff>(), new List<Event>())}, new List<Staff>(),
                new List<Customer>(), _location, new List<Ticket>(), true, false, false);
    }
    
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

    [Fact]
    public void AddEventTest()
    {
        _location.AddEvent(_event);
        
        Assert.Contains(_event, _location.GetEventsAssigned());
        Assert.Equal(_location, _event.GetLocation());
    }

    [Fact]
    public void RemoveEventTest()
    {
        _location.RemoveEvent(_event);
        
        Assert.DoesNotContain(_event, _location.EventsAssigned);
    }

    [Fact]
    public void UpdateEventTest()
    {
        _location.UpdateEvent(_event);
        
        Assert.Contains(_event, _location.GetEventsAssigned());
    }
}