using EventSystem.Classes;

namespace EventSystem.Tests;

public class HiringClassTests
{
    private Hiring _hiring = new Hiring(new Staff("Henry", "Grey",
        "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
        Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 599.99m, new List<Event>(),
        new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
        null, new List<Staff>()), new Organizer("Anne", "Grey",
        "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()), 
        new DateOnly(2025, 01, 01), null);

    [Fact]
    public void HiringCreationTest()
    {
        Assert.Equal("Henry", _hiring.Staff.Name);
        Assert.Equal("Grey", _hiring.Staff.Surname);
        Assert.Equal("test@gmail.com", _hiring.Staff.Email);
        Assert.Equal("+48573370352", _hiring.Staff.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _hiring.Staff.BirthDate);
        Assert.Equal(Staff.StaffRole.Bartender, _hiring.Staff.Role);
        Assert.Equal("Poland", _hiring.Staff.Address.Country);
        Assert.Equal("Warsaw", _hiring.Staff.Address.City);
        Assert.Equal("Al. Wilanowska 12", _hiring.Staff.Address.Street);
        Assert.Equal("125", _hiring.Staff.Address.AppNumber);
        Assert.Equal("02-123", _hiring.Staff.Address.Index);
        Assert.Equal(new List<Staff>(), _hiring.Staff.Address.Staff);
        Assert.Equal(599.99m, _hiring.Staff.Salary);
        Assert.Equal("Anne", _hiring.Staff.Organizer.Name);
        Assert.Equal("Grey", _hiring.Staff.Organizer.Surname);
        Assert.Equal(19999.99m, _hiring.Staff.Organizer.Profit);
        Assert.Null(_hiring.Staff.Manager);
        Assert.Equal(new List<Staff>(), _hiring.Staff.Subordinates);
        Assert.Equal("Anne", _hiring.Organizer.Name);
        Assert.Equal("Grey", _hiring.Organizer.Surname);
        Assert.Equal(19999.99m, _hiring.Organizer.Profit);
        Assert.Equal(new DateOnly(2025, 1, 1), _hiring.DateHired);
        Assert.Null(_hiring.DateFired);
    }
}