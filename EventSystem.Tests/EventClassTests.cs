using EventSystem.Classes;

namespace EventSystem.Tests;

public class EventClassTests
{
    private Event _event = new Event("New Event",
        new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
        new List<Organizer>(), new List<Staff>(), new List<Customer>(),
        new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>());
    
    [Fact]
    public void EventCreationTest()
    {
        Assert.Equal("New Event", _event.Title);
        Assert.Equal(new DateTime(2025, 12, 12), _event.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _event.EndDateAndTime);
        Assert.Equal("New event", _event.Description);
        Assert.Equal(new List<Organizer>(), _event.Organizers);
        Assert.Equal(new List<Staff>(), _event.StaffAssigned);
        Assert.Equal(new List<Customer>(), _event.InWhoseWishList);
        Assert.Equal(10000, _event.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _event.Location.Address);
        Assert.Equal(new List<Event>(), _event.Location.EventsAssigned);
        Assert.Equal(new List<Ticket>(), _event.TicketsForEvent);
    }

    [Fact]
    public void EventTitleNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("",
            new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("Title cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void EventDecriptionNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("New Event",
            new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("Description cannot be empty.", ex.Message);
    }

    [Fact]
    public void EventStartDateEndDateWrongTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("New Event",
            new DateTime(2025, 12, 23), new DateTime(2025, 12, 12), "New event",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("End date cannot be before start date.", ex.Message);
    }

    [Fact]
    public void EventStartDateBeforeCurrentDateTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("New Event",
            new DateTime(2025, 10, 10), new DateTime(2025, 12, 23), "New event",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("Start date cannot be before current date.", ex.Message);
    }
}