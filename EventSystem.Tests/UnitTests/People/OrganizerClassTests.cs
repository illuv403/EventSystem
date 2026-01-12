using System.Runtime.Loader;
using EventSystem.Classes;

namespace EventSystem.Tests;

public class OrganizerClassTests
{
    private Organizer _organizer;
    private Organizer _organizer2;

    private Event _event1;
    private Event _event2;
    
    private Staff _staff5;
    
    private Hiring _hiring1;
    private Hiring _hiring2;

    public OrganizerClassTests()
    {
        _organizer = new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>());
        
        _organizer2 = new Organizer("Ann", "Brown",
            "test@gmail.com", "+48573370352",
            new DateOnly(2001, 1, 1), 19999.99m, new List<Staff>(), new List<Event>());

        _event1 = new Event("New Event", new DateTime(2026, 02, 14), new DateTime(2026, 02, 17), "New event",
            new List<Organizer>
            {
                new("Alice", "Black",
                    "test6546@gmail.com", "+48573073352",
                    new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())
            },
            new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()),
            new List<Ticket>(), true, false, false);
        
        _event2 = new Event("My Event", new DateTime(2026, 03, 01), new DateTime(2026, 03, 03), "My event",
            new List<Organizer> {new("Mial", "Iwonas",
                "test6546@gmail.com", "+48565251352",
                new DateOnly(1981, 4, 14), 19999.99m, new List<Staff>(), new List<Event>())}, 
            new List<Staff>(), new List<Customer>(),
            new Location(16000, "ul. Poznańska 13", new List<Event>()), 
            new List<Ticket>(), true, false, false);
        
        _staff5 = new Staff("Henry", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender, new Address("Ukraine", "Kharkov",
                "St. Plekhanovskaya 5", "11", "61001", new List<Staff>()), 599.99m, new List<Event>(),
            _organizer,  new DateOnly(2024, 2, 1),
            null, new List<Staff>());
        
        
        _hiring1 = new Hiring(_staff5, _organizer, new DateOnly(2024, 2, 1));
        _hiring2 = new Hiring(_staff5, _organizer2, new DateOnly(2025, 10, 12));
    }
    
    [Fact]
    public void OrganizerCreationTest()
    {
        Assert.Equal("Anne", _organizer.Name);
        Assert.Equal("Grey", _organizer.Surname);
        Assert.Equal("test@gmail.com", _organizer.Email);
        Assert.Equal("+48573370352", _organizer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _organizer.BirthDate);
        Assert.Equal(19999.99m, _organizer.Profit);
        Assert.Equal(new List<Staff>(),  _organizer.Staff);
        Assert.Equal(new List<Event>(), _organizer.Events);
    }

    [Fact]
    public void AddOrganizerEventTest()
    {
        _organizer.AddAssignedEvent(_event1);
        
        Assert.Contains(_event1, _organizer.GetAssignedEvents());
        Assert.Contains(_organizer, _event1.GetEventOrganizers());
    }

    [Fact]
    public void RemoveOrganizerEventTest()
    {
        _organizer.RemoveAssignedEvent(_event1);
        
        Assert.DoesNotContain(_event1, _organizer.GetAssignedEvents());
        Assert.DoesNotContain(_organizer, _event1.GetEventOrganizers());
    }

    [Fact]
    public void UpdateOrganizerEventTest()
    {
        _organizer.AddAssignedEvent(_event1);
        _organizer.UpdateAssignedEvents(_event1, _event2);
        
        Assert.DoesNotContain(_event1, _organizer.GetAssignedEvents());
        Assert.Contains(_event2, _organizer.GetAssignedEvents());
        
        Assert.DoesNotContain(_organizer, _event1.GetEventOrganizers());
        Assert.Contains(_organizer, _event2.GetEventOrganizers());
    }
    
    [Fact]
    public void AddHiringTest()
    {
        _organizer.AddHiring(_hiring1);
        Assert.Equal(_hiring1 ,_organizer.GetHiringHistory().Last());
        
        var hiring = _staff5.GetHiringHistory().Last();
        
        Assert.Equal(_staff5, hiring.Staff);
        Assert.Equal(_organizer, hiring.Organizer);
        Assert.Equal( new DateOnly(2024, 2, 1), hiring.DateHired);
        Assert.Null(hiring.DateFired);
    }
    
    [Fact]
    public void RemoveHiringTest()
    {
        var hiringHistory = _organizer.GetHiringHistory();
        Assert.Single(hiringHistory);
        
        
        hiringHistory.Last().Fire(new DateOnly(2025, 10, 12));
        
        _organizer.AddHiring(_hiring2);
        hiringHistory = _organizer.GetHiringHistory();
        
        Assert.Equal(2, hiringHistory.Count);
        
        _organizer.RemoveHiring(hiringHistory.Last());
        
        hiringHistory = _organizer.GetHiringHistory();
        Assert.Single(hiringHistory);
        
        Assert.Equal(new DateOnly(2025, 10, 12), hiringHistory.Single().DateFired);
    }
    
    
    [Fact]
    public void ChangeToStaffTest()
    {
        Staff expectedStaff = new("Anne", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender, new Address("Poland", "Warsaw", "Al. Wilanowska 12", "125", "02-123", new List<Staff>()),
            19999.99m, new List<Event>(),
            new Organizer("Ben", "White","test@gmail.com", "+48572512352", new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()), 
            new DateOnly(2000, 2, 1),
            null, new List<Staff>());

        Staff organizerToStaff = _organizer.ChangeToStaff(Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
                "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 19999.99m, new List<Event>(),
            new Organizer("Ben", "White",
                "test@gmail.com", "+48572512352",
                new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
            new DateOnly(2000, 2, 1),
            null, new List<Staff>());

        Assert.Equal(expectedStaff.Name, organizerToStaff.Name);
        Assert.Equal(expectedStaff.Surname, organizerToStaff.Surname);
        Assert.Equal(expectedStaff.Email, organizerToStaff.Email);
        Assert.Equal(expectedStaff.PhoneNumber, organizerToStaff.PhoneNumber);
        Assert.Equal(expectedStaff.Address.Country, organizerToStaff.Address.Country);
        Assert.Equal(expectedStaff.Address.City, organizerToStaff.Address.City);
        Assert.Equal(expectedStaff.Address.Street, organizerToStaff.Address.Street);
        Assert.Equal(expectedStaff.Address.AppNumber, organizerToStaff.Address.AppNumber);
        Assert.Equal(expectedStaff.Address.Index, organizerToStaff.Address.Index);
        Assert.Equal(expectedStaff.Address.Staff, organizerToStaff.Address.Staff);
        Assert.Equal(expectedStaff.Salary, organizerToStaff.Salary);
        Assert.Equal(expectedStaff.Events, organizerToStaff.Events);
        Assert.Equal(expectedStaff.Organizer?.Name, organizerToStaff.Organizer.Name);
        Assert.Equal(expectedStaff.Organizer?.Surname, organizerToStaff.Organizer.Surname);
        Assert.Equal(expectedStaff.Organizer?.Email, organizerToStaff.Organizer.Email);
        Assert.Equal(expectedStaff.Organizer?.PhoneNumber, organizerToStaff.Organizer.PhoneNumber);
        Assert.Equal(expectedStaff.Organizer?.BirthDate, organizerToStaff.Organizer.BirthDate);
        Assert.Equal(expectedStaff.Organizer?.Profit, organizerToStaff.Organizer.Profit);
        Assert.Equal(expectedStaff.Organizer?.Staff, organizerToStaff.Organizer.Staff);
        Assert.Equal(expectedStaff.Organizer?.Events, organizerToStaff.Organizer.Events);
        Assert.Equal(expectedStaff.BirthDate, organizerToStaff.BirthDate);
        Assert.Equal(expectedStaff.Manager, organizerToStaff.Manager);
        Assert.Equal(expectedStaff.Subordinates, organizerToStaff.Subordinates);
    }

    [Fact]
    public void ChangeToCustomerTest()
    {
        Customer expectedCustomer = new Customer("Anne",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>());
        
        Customer organizerToCustomer = _organizer.ChangeToCustomer(new List<Order>());
        
        Assert.Equal(expectedCustomer.Name, organizerToCustomer.Name);
        Assert.Equal(expectedCustomer.Surname, organizerToCustomer.Surname);
        Assert.Equal(expectedCustomer.Email, organizerToCustomer.Email);
        Assert.Equal(expectedCustomer.PhoneNumber, organizerToCustomer.PhoneNumber);
        Assert.Equal(expectedCustomer.BirthDate, organizerToCustomer.BirthDate);
        Assert.Equal(expectedCustomer.Orders, organizerToCustomer.Orders);
    }
}