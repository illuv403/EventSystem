using EventSystem.Classes;

namespace EventSystem.Tests;

public class MusicalClassTests
{
    private Musical _musical = new Musical("Musical", new DateTime(2025, 12, 11), 
        new DateTime(2025, 12, 23), "New musical", new List<Organizer>(), new List<Staff>(),
        new List<Customer>(), new Location(10000, "Al. Wilanowska 12", new List<Event>()),
        new List<Ticket>());
    
    [Fact]
    public void MusicalCreationTest()
    {
        Assert.Equal("Musical", _musical.Title);
        Assert.Equal(new DateTime(2025, 12, 11), _musical.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _musical.EndDateAndTime);
        Assert.Equal("New musical", _musical.Description);
        Assert.Equal(new List<Organizer>(), _musical.Organizers);
        Assert.Equal(new List<Staff>(), _musical.StaffAssigned);
        Assert.Equal(new List<Customer>(), _musical.InWhoseWishList);
        Assert.Equal(10000, _musical.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _musical.Location.Address);
        Assert.Equal(new List<Event>(), _musical.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _musical.TicketsForEvent);
    }
}