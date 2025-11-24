using EventSystem.Classes;

namespace EventSystem.Tests;

public class SportClassTests
{
    private Sport _sport = new Sport("Sport", new DateTime(2025, 12, 11), 
        new DateTime(2025, 12, 23), "New sport", new List<Organizer>(), new List<Staff>(),
        new List<Customer>(), new Location(10000, "Al. Wilanowska 12", new List<Event>()),
        new List<Ticket>());
    
    [Fact]
    public void SportCreationTest()
    {
        Assert.Equal("Sport", _sport.Title);
        Assert.Equal(new DateTime(2025, 12, 11), _sport.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _sport.EndDateAndTime);
        Assert.Equal("New sport", _sport.Description);
        Assert.Equal(new List<Organizer>(), _sport.Organizers);
        Assert.Equal(new List<Staff>(), _sport.StaffAssigned);
        Assert.Equal(new List<Customer>(), _sport.InWhoseWishList);
        Assert.Equal(10000, _sport.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _sport.Location.Address);
        Assert.Equal(new List<Event>(), _sport.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _sport.TicketsForEvent);
    }
}