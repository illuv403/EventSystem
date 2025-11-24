using EventSystem.Classes;

namespace EventSystem.Tests;

public class OrganizerClassTests
{
    private Organizer _organizer = new Organizer("Anne", "Grey",
        "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>());

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
}