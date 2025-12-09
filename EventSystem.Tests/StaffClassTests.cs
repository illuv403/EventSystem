using EventSystem.Classes;

namespace EventSystem.Tests;

public class StaffClassTests
{
    private Staff _staff;
    private Event _event1;
    private Event _event2 = new Event("New Event 2",
        new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event 2",
        new List<Organizer> {new("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
        new List<Staff>(), new List<Customer>(),
        new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
        new List<Ticket>());

    public StaffClassTests()
    {
        _staff = new Staff("Henry", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
                "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 599.99m, new List<Event>(),
            new Organizer("Anne", "Grey",
                "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
            null, new List<Staff>());
        _event1 = new Event("New Event",
            new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
            new List<Organizer> {new("Alice", "Black",
                "test6546@gmail.com", "+48573073352",
                new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
            new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
            new List<Ticket>());
    }
    
    [Fact]
    public void StaffCreationTest()
    {
        Assert.Equal("Henry", _staff.Name);
        Assert.Equal("Grey", _staff.Surname);
        Assert.Equal("test@gmail.com", _staff.Email);
        Assert.Equal("+48573370352", _staff.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _staff.BirthDate);
        Assert.Equal(Staff.StaffRole.Bartender, _staff.Role);
        Assert.Equal("Poland", _staff.Address.Country);
        Assert.Equal("Warsaw", _staff.Address.City);
        Assert.Equal("Al. Wilanowska 12", _staff.Address.Street);
        Assert.Equal("125", _staff.Address.AppNumber);
        Assert.Equal("02-123", _staff.Address.Index);
        Assert.Equal(new List<Staff>(), _staff.Address.Staff);
        Assert.Equal(599.99m, _staff.Salary);
        Assert.Equal(new List<Event>(), _staff.Events);
        Assert.Equal("Anne", _staff.Organizer.Name);
        Assert.Equal("Grey", _staff.Organizer.Surname);
        Assert.Equal(19999.99m, _staff.Organizer.Profit);
        Assert.Null(_staff.Manager);
    }
    
    [Fact]
    public void StaffSalaryNegativeTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Staff("Henry", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
                "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), -10m, new List<Event>(),
            new Organizer("Anne", "Grey",
                "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
            null, new List<Staff>()));
        Assert.Equal("Salary cannot be negative", ex.Message);
    }

    [Fact]
    public void AddAssignedEventTest()
    {
        _staff.AddAssignedEvent(_event1);
        
        Assert.Contains(_event1, _staff.GetAssignedEvents());
        Assert.Contains(_staff, _event1.GetStaffAssigned());
    }

    [Fact]
    public void RemoveAssignedEventTest()
    {
        _staff.AddAssignedEvent(_event1);
        _staff.RemoveAssignedEvent(_event1);
        
        Assert.DoesNotContain(_event1, _staff.GetAssignedEvents());
        Assert.DoesNotContain(_staff, _event1.GetStaffAssigned());
    }

    [Fact]
    public void UpdateAssignedEventTest()
    {
        _staff.AddAssignedEvent(_event1);
        _staff.UpdateAssignedEvent(_event1, _event2);
        
        Assert.DoesNotContain(_event1, _staff.GetAssignedEvents());
        Assert.Contains(_event2, _staff.GetAssignedEvents());
        
        Assert.DoesNotContain(_staff, _event1.GetStaffAssigned());
        Assert.Contains(_staff, _event2.GetStaffAssigned());
    }
}