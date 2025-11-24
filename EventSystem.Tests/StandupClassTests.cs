using EventSystem.Classes;

namespace EventSystem.Tests;

public class StandupClassTests
{
    private Standup _standup = new Standup("Standup", new DateTime(2025, 12, 11), 
        new DateTime(2025, 12, 23), "New standup", new List<Organizer>(), new List<Staff>(),
        new List<Customer>(), new Location(10000, "Al. Wilanowska 12", new List<Event>()),
        new List<Ticket>());
    
    [Fact]
    public void StandupCreationTest()
    {
        Assert.Equal("Standup", _standup.Title);
        Assert.Equal(new DateTime(2025, 12, 11), _standup.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _standup.EndDateAndTime);
        Assert.Equal("New standup", _standup.Description);
        Assert.Equal(new List<Organizer>(), _standup.Organizers);
        Assert.Equal(new List<Staff>(), _standup.StaffAssigned);
        Assert.Equal(new List<Customer>(), _standup.InWhoseWishList);
        Assert.Equal(10000, _standup.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _standup.Location.Address);
        Assert.Equal(new List<Event>(), _standup.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _standup.TicketsForEvent);
    }
}
