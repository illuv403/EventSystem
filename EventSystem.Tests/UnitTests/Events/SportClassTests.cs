using EventSystem.Classes;

namespace EventSystem.Tests;

public class SportClassTests
{
    private Sport _sport = new Sport("Sport", new DateTime(2025, 12, 27), 
        new DateTime(2025, 12, 30), "New sport", 
        new List<Organizer>{new("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
        new List<Staff>(),
        new List<Customer>(), new Location(10000, "Al. Wilanowska 12", 
            new List<Event>()), new List<Ticket>());
    
    [Fact]
    public void SportCreationTest()
    {
        Assert.Equal("Sport", _sport.Title);
        Assert.Equal(new DateTime(2025, 12, 27), _sport.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 30), _sport.EndDateAndTime);
        Assert.Equal("New sport", _sport.Description);
        Assert.Single(_sport.Organizers);
        Assert.Equal(new List<Staff>(), _sport.StaffAssigned);
        Assert.Equal(new List<Customer>(), _sport.InWhoseWishList);
        Assert.Equal(10000, _sport.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _sport.Location.Address);
        Assert.Equal(new List<Event>(), _sport.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _sport.TicketsForEvent);
    }
}