using System.Runtime.Loader;
using EventSystem.Classes;

namespace EventSystem.Tests;

public class OrganizerClassTests
{
    private Organizer _organizer;

    private Event _event1;
    private Event _event2;

    public OrganizerClassTests()
    {
        _organizer = new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>());
        
        _event1 = new Event("New Event", new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
            new List<Organizer> {new("Alice", "Black",
                "test6546@gmail.com", "+48573073352",
                new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
            new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
            new List<Ticket>());
        
        _event2 = new Event("My Event", new DateTime(2026, 01, 12), new DateTime(2026, 01, 14), "My event",
            new List<Organizer> {new("Mial", "Iwonas",
                "test6546@gmail.com", "+48565251352",
                new DateOnly(1981, 4, 14), 19999.99m, new List<Staff>(), new List<Event>())}, 
            new List<Staff>(), new List<Customer>(),
            new Location(16000, "ul. Poznańska 13", new List<Event>()), 
            new List<Ticket>());
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
}