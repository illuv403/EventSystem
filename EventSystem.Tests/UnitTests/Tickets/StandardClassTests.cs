using EventSystem.Classes;

namespace EventSystem.Tests;

public class StandardClassTests
{
    private Standard _standard = new Standard("A12", 49.99m, "123",new Event("New Event",
        new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event", 
        new List<Organizer>{new("Alice", "Black",
            "test6546@gmail.com", "+48573073352",
            new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
        new List<Staff>(), new List<Customer>(), 
        new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>()), 
        new Order("ID1", new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ), new List<Ticket>()));
    
    [Fact]
    public void StandardCreationTest()
    {
        Assert.Equal("A12", _standard.GateNumber);
        Assert.Equal(49.99m, _standard.Price);
        Assert.Equal("123", _standard.SeatNumber);
        Assert.Equal("New Event", _standard.EventForTicket.Title);
        Assert.Equal(new DateTime(2025, 12, 27), _standard.EventForTicket.StartDateAndTime);
        Assert.Equal(new DateTime(2025, 12, 30), _standard.EventForTicket.EndDateAndTime);
        Assert.Equal("New event", _standard.EventForTicket.Description);
        Assert.Equal(10000, _standard.EventForTicket.Location.Capacity);
        Assert.Equal("Al. Wilanowska 12", _standard.EventForTicket.Location.Address);
        Assert.Equal("Henry", _standard.Order.CreatedByCustomer.Name);
        Assert.Equal("Grey", _standard.Order.CreatedByCustomer.Surname);
        Assert.Equal("test@gmail.com", _standard.Order.CreatedByCustomer.Email);
        Assert.Equal("+48573370352", _standard.Order.CreatedByCustomer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1 , 1), _standard.Order.CreatedByCustomer.BirthDate);
    }
}