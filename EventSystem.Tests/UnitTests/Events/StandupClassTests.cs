using EventSystem.Classes;

namespace EventSystem.Tests;

public class StandupClassTests
{
    private Standup _standup = new Standup("Standup", new DateTime(2025, 12, 27), 
        new DateTime(2025, 12, 30), "New standup", 
        new List<Organizer>{new("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
        new List<Staff>(),
        new List<Customer>(), new Location(10000, "Al. Wilanowska 12", 
            new List<Event>()), new List<Ticket>());
    
    [Fact]
    public void StandupCreationTest()
    {
        Assert.Equal("Standup", _standup.Title);
        Assert.Equal(new DateTime(2025, 12, 27), _standup.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 30), _standup.EndDateAndTime);
        Assert.Equal("New standup", _standup.Description);
        Assert.Single(_standup.Organizers);
        Assert.Equal(new List<Staff>(), _standup.StaffAssigned);
        Assert.Equal(new List<Customer>(), _standup.InWhoseWishList);
        Assert.Equal(10000, _standup.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _standup.Location.Address);
        Assert.Equal(new List<Event>(), _standup.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _standup.TicketsForEvent);
    }
}
