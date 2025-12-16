using EventSystem.Classes;

namespace EventSystem.Tests;

public class EventClassTests
{
    private Event _event;
    private Staff _staff1;
    private Staff _staff2;

    private Customer _customer1;
    private Customer _customer2;

    private Organizer _organizer1;
    private Organizer _organizer2;

    private Ticket _ticket1;

    private Location _location;
    
    public EventClassTests()
    {
        _event = new Event("New Event",
            new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event",
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
        
        _staff2 = new("Bob", "Grey",
            "test5@gmail.com", "+48537370532", new DateOnly(1999, 12, 5),
            Staff.StaffRole.Cameramen, new Address("Ukraine", "Kharkov",
                "St. Plekhanovskaya 5", "11", "61001", new List<Staff>()), 599.99m, 
            new List<Event>(), new Organizer("Alice", "Black",
                "test6546@gmail.com", "+48573073352",
                new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>()),
            null, new List<Staff>());
        
        _customer1 = new("Daniel", "Eroth", "d.eroth@gmail.com", "+48578998756", new DateOnly(2005, 07, 01), new List<Order>());
        _customer2 = new("Michael", "Cannon", "cannon.mike@yahoo.com", "+48568196126", new DateOnly(1999, 12, 12), new List<Order>());
        
        _organizer1 = new("Alexandra", "Kowalska", "kow.all@gmail.com", "+48533245654", new DateOnly(1988, 01, 01),
            2290.0m, new List<Staff>(), new List<Event>());
        _organizer2 = new("Alex", "Mikolajewski", "mikiaxi@gmail.com", "+48378198856", new DateOnly(1978, 06, 12),
            1910.99m, new List<Staff>(), new List<Event>());

        _ticket1 = new Standard("G-21", 199.39m, "S203", _event, new Order("ID1", _customer1, new List<Ticket>()));
        
        _location = new Location(10000, "Al. Wilanowska 12", new List<Event>());
    }
    
    [Fact]
    public void EventCreationTest()
    {
        Assert.Equal("New Event", _event.Title);
        Assert.Equal(new DateTime(2025, 12, 27), _event.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 30), _event.EndDateAndTime);
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
            new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("Title cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void EventDescriptionNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("New Event",
            new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()));
        Assert.Equal("Description cannot be empty.", ex.Message);
    }

    [Fact]
    public void EventStartDateEndDateWrongTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Event("New Event",
            new DateTime(2025, 12, 30), new DateTime(2025, 12, 27), "New event",
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
    
    
    // -- Customer -- //
    [Fact]
    public void AddCustomerToEventTest()
    {
        _event.AddInWishList(_customer1);

        Assert.Contains(_customer1, _event.GetInWhoseWishList());
        Assert.Contains(_event, _customer1.WishesForEvent());
    }

    [Fact]
    public void RemoveCustomerFromEventTest()
    {
        _event.RemoveInWishList(_customer1);
        
        Assert.DoesNotContain(_customer1, _event.GetInWhoseWishList());
        Assert.DoesNotContain(_event, _customer1.WishesForEvent());
    }

    [Fact]
    public void UpdateCustomerEventTest()
    {
        _event.AddInWishList(_customer1);
        _event.UpdateInWishList(_customer1, _customer2);
        
        Assert.DoesNotContain(_customer1, _event.GetInWhoseWishList());
        Assert.Contains(_customer2, _event.GetInWhoseWishList());
        
        Assert.DoesNotContain(_event, _customer1.WishesForEvent());
        Assert.Contains(_event, _customer2.WishesForEvent());
    }
    
    // -- Organizer -- //
    [Fact]
    public void AddOrganizerToEventTest()
    {
        _event.AddEventOrganizer(_organizer1);
        
        Assert.Contains(_organizer1, _event.GetEventOrganizers());
        Assert.Contains(_event, _organizer1.GetAssignedEvents());
    }

    [Fact]
    public void RemoveOrganizerFromEventTest()
    {
        _event.RemoveEventOrganizer(_organizer1);
        
        Assert.DoesNotContain(_organizer1, _event.GetEventOrganizers());
        Assert.DoesNotContain(_event, _organizer1.GetAssignedEvents());
    }

    [Fact]
    public void UpdateOrganizerEventTest()
    {
        _event.AddEventOrganizer(_organizer1);
        _event.UpdateEventOrganizers(_organizer1, _organizer2);
        
        Assert.DoesNotContain(_organizer1, _event.GetEventOrganizers());
        Assert.Contains(_organizer2, _event.GetEventOrganizers());
        
        Assert.DoesNotContain(_event, _organizer1.GetAssignedEvents());
        Assert.Contains(_event, _organizer2.GetAssignedEvents());
    }
    
    // Ticket // 
    [Fact]
    public void AddTicketToEventTest()
    {
        _event.AddTicket(_ticket1);

        Assert.Contains(_ticket1, _event.GetTicketsForEvent());
        Assert.Equal(_event, _ticket1.GetEventForTicket());
    }

    [Fact]
    public void RemoveTicketFromEventTest()
    {
        _event.RemoveTicket(_ticket1);
        
        Assert.DoesNotContain(_ticket1, _event.GetTicketsForEvent());
    }

    [Fact]
    public void UpdateTicketOfEventTest()
    {
        _event.AddTicket(_ticket1);
        _event.UpdateTicket(_ticket1);

        Assert.Contains(_ticket1, _event.GetTicketsForEvent());
        Assert.Equal(_event, _ticket1.GetEventForTicket());
    }
    
    // Location //
    [Fact]
    public void UpdateLocationOfEventTest()
    {
        _event.UpdateLocation(_location);
        
        Assert.Contains(_event, _location.GetEventsAssigned());
    }
}