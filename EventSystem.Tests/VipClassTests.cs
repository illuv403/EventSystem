using EventSystem.Classes;

namespace EventSystem.Tests;

public class VipClassTests
{
    private Vip _vip = new Vip("A12", 49.99m, "3",new Event("New Event",
            new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event", 
            new List<Organizer>{new("Alice", "Black",
                "test6546@gmail.com", "+48573073352",
                new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
            new List<Staff>(), new List<Customer>(), 
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
            new List<Ticket>()), new Order(new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ), new List<Ticket>()));

    [Fact]
    public void VipCreationTest()
    {
        Assert.Equal("A12", _vip.GateNumber);
        Assert.Equal(49.99m, _vip.Price);
        Assert.Equal("3", _vip.LoungeNumber);
        Assert.Equal("New Event", _vip.EventForTicket.Title);
        Assert.Equal(new DateTime(2025, 12, 12), _vip.EventForTicket.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _vip.EventForTicket.EndDateAndTime);
        Assert.Equal("New event", _vip.EventForTicket.Description);
        Assert.Equal(10000, _vip.EventForTicket.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _vip.EventForTicket.Location.Address);
        Assert.Equal("Henry", _vip.Order.CreatedByCustomer.Name);
        Assert.Equal("Grey", _vip.Order.CreatedByCustomer.Surname);
        Assert.Equal("test@gmail.com", _vip.Order.CreatedByCustomer.Email);
        Assert.Equal("+48573370352", _vip.Order.CreatedByCustomer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1 , 1), _vip.Order.CreatedByCustomer.BirthDate);
    }

    [Fact]
    public void VipGateNumberNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Vip("", 49.99m, "3", new Event("New Event",
                new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
                new List<Organizer>{new("Alice", "Black",
                    "test6546@gmail.com", "+48573073352",
                    new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), 
                    new List<Event>())}, new List<Staff>(), new List<Customer>(),
                new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
                new List<Ticket>()),
            new Order(new Customer("Henry",
                "Grey", "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), new List<Order>()
            ), new List<Ticket>())));
        Assert.Equal("Gate number cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void VipNegativePriceGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Vip("A12", -10m, "3", new Event("New Event",
                new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
                new List<Organizer>{new("Alice", "Black",
                    "test6546@gmail.com", "+48573073352",
                    new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())},
                new List<Staff>(), new List<Customer>(),
                new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
                new List<Ticket>()), new Order(new Customer("Henry",
                "Grey", "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), new List<Order>()
            ), new List<Ticket>())));
        Assert.Equal("Price cannot be negative.", ex.Message);
    }
}