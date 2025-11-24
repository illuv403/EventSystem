using EventSystem.Classes;

namespace EventSystem.Tests;

public class StaffClassTests
{
    private Staff _staff = new Staff("Henry", "Grey",
        "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
        Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 599.99m, new List<Event>(),
        new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
        null, new List<Staff>());
    
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
}