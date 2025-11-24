using EventSystem.Classes;

namespace EventSystem.Tests;

public class FanZoneClassTests
{
    private FanZone _fanZone = new FanZone("A12", 49.99m, new Event("New Event",
        new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event", 
        new List<Organizer>(), new List<Staff>(), new List<Customer>(), 
        new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()), 
        new Order(new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ), new List<Ticket>()));

    [Fact]
    public void FanZoneCreationTest()
    {
        Assert.Equal("A12", _fanZone.GateNumber);
        Assert.Equal(49.99m, _fanZone.Price);
        Assert.Equal("New Event", _fanZone.EventForTicket.Title);
        Assert.Equal(new DateTime(2025, 12, 12), _fanZone.EventForTicket.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 23), _fanZone.EventForTicket.EndDateAndTime);
        Assert.Equal("New event", _fanZone.EventForTicket.Description);
        Assert.Equal(10000, _fanZone.EventForTicket.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _fanZone.EventForTicket.Location.Address);
        Assert.Equal("Henry", _fanZone.Order.CreatedByCustomer.Name);
        Assert.Equal("Grey", _fanZone.Order.CreatedByCustomer.Surname);
        Assert.Equal("test@gmail.com", _fanZone.Order.CreatedByCustomer.Email);
        Assert.Equal("+48573370352", _fanZone.Order.CreatedByCustomer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1 , 1), _fanZone.Order.CreatedByCustomer.BirthDate);
    }
}