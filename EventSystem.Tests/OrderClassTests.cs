using EventSystem.Classes;

namespace EventSystem.Tests;

public class OrderClassTests
{
    private Order _order = new Order(new Customer("Henry",
        "Grey", "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1), new List<Order>()
    ), new List<Ticket>());

    [Fact]
    public void OrderCreationTest()
    {
        Assert.Equal("Henry", _order.CreatedByCustomer.Name);
        Assert.Equal("Grey", _order.CreatedByCustomer.Surname);
        Assert.Equal("test@gmail.com", _order.CreatedByCustomer.Email);
        Assert.Equal("+48573370352", _order.CreatedByCustomer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _order.CreatedByCustomer.BirthDate);
        Assert.Equal(new List<Order>(), _order.CreatedByCustomer.Orders);
        Assert.Equal(new List<Ticket>(), _order.TicketsInOrder);
    }
}