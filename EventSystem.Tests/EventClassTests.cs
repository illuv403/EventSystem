using EventSystem.Classes;

namespace EventSystem.Tests;

public class EventClassTests
{
    private Event _event;
    private Staff _staff1;
    private Staff _staff2 = new Staff("Bob", "Grey",
        "test5@gmail.com", "+48537370532", new DateOnly(1999, 12, 5),
        Staff.StaffRole.Cameramen, new Address("Ukraine", "Kharkov",
            "St. Plekhanovskaya 5", "11", "61001", new List<Staff>()), 599.99m, 
        new List<Event>(), new Organizer("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>()),
        null, new List<Staff>());

    public EventClassTests()
    {
    _event = new Event("New Event",
        new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
        new List<Organizer> {new("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
        new List<Staff>(), new List<Customer>(),
        new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
        new List<Ticket>());
    
    _staff1 = new Staff("Henry", "Grey",
        "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
        Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 599.99m, 
        new List<Event>(), new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
        null, new List<Staff>());
    }
    
    [Fact]
    public void EventCreationTest()
    {
        Assert.Equal("New Event", _event.Title);
        Assert.Equal(new DateTime(2025, 12, 12), _event.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _event.EndDateAndTime);
        Assert.Equal("New event", _event.Description);
        Assert.Single(_event.Organizers);
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
    public void EventDescriptionNotGivenTest()
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

    [Fact]
    public void AddStaffToEventTest()
    {
        _event.AddStaffAssigned(_staff1);
        Assert.Contains(_staff1, _event.GetStaffAssigned());
        Assert.Contains(_event, _staff1.GetAssignedEvents());
    }

    [Fact]
    public void RemoveStaffFromEventTest()
    {
        _event.AddStaffAssigned(_staff1);
        _event.RemoveStaffAssigned(_staff1);
        
        Assert.DoesNotContain(_staff1, _event.GetStaffAssigned());
        Assert.DoesNotContain(_event, _staff1.GetAssignedEvents());
    }

    [Fact]
    public void UpdateStaffEventTest()
    {
        _event.AddStaffAssigned(_staff1);
        _event.UpdateStaffAssigned(_staff1, _staff2);
        
        Assert.DoesNotContain(_staff1, _event.GetStaffAssigned());
        Assert.Contains(_staff2, _event.GetStaffAssigned());
        
        Assert.DoesNotContain(_event, _staff1.GetAssignedEvents());
        Assert.Contains(_event, _staff2.GetAssignedEvents());
    }
}