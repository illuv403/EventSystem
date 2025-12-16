using EventSystem.Classes;

namespace EventSystem.Tests;

public class OrderClassTests
{
    private Order _order;

    private Ticket _ticketStandard;
    private Ticket _ticketVip;

    private Customer _customer;

    public OrderClassTests()
    {
        _order = new Order("ID1", new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ), new List<Ticket>());
        
        _ticketStandard = new Vip("G4", 199.99m, "L-2", 
            new Event("New Event",
                new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event",
                new List<Organizer> {new("Alice", "Black",
                    "test6546@gmail.com", "+48573073352",
                    new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
                new List<Staff>(), new List<Customer>(),
                new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
                new List<Ticket>()), 
            new Order("ID1", new Customer("Henry",
                "Grey", "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), new List<Order>()
            ), new List<Ticket>()));
        
        _ticketVip = new Vip("G4", 199.99m, "L-2", 
            new Event("New Event",
                new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event",
                new List<Organizer> {new("Alice", "Black",
                    "test6546@gmail.com", "+48573073352",
                    new DateOnly(1995, 5, 4), 19999.99m, new List<Staff>(), new List<Event>())}, 
                new List<Staff>(), new List<Customer>(),
                new Location(10000, "Al. Wilanowska 12", new List<Event>()), 
                new List<Ticket>()), 
            new Order("ID1", new Customer("Henry",
                "Grey", "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), new List<Order>()
            ), new List<Ticket>()));

        _customer = new Customer("Johny", "Millenar", "test@gmail.com",
            "+48765489182", new DateOnly(2000, 12, 12), new List<Order>());
    }
    
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

    [Fact]
    public void AddTicketToOrderTest()
    {
        _order.AddTicketToOrder(_ticketStandard);
        Assert.Contains(_ticketStandard, _order.GetTicketsInOrder());
    }

    [Fact]
    public void RemoveTicketFromOrderTest()
    {
        _order.RemoveTicketFromOrder(_ticketStandard);
        Assert.DoesNotContain(_ticketStandard, _order.GetTicketsInOrder());
    }

    [Fact]
    public void UpdateTicketInOrderTest()
    {
        _order.UpdateTicketsInOrder(_ticketStandard, _ticketVip);
        
        Assert.DoesNotContain(_ticketStandard, _order.GetTicketsInOrder());
        Assert.Contains(_ticketVip, _order.GetTicketsInOrder());
    }
    
    // Customer //
    [Fact]
    public void AddOrderToCustomerTest()
    {
        _order.AddToCustomer(_customer);
        
        Assert.Contains(_order, _customer.GetCustomerOrders());
        Assert.Equal(_customer, _order.GetCreatedByCustomer());
    }

    [Fact]
    public void RemoveOrderFromCustomerTest()
    {
        _order.AddToCustomer(_customer);
        _order.RemoveFromCustomer();
        
        Assert.DoesNotContain(_order, _customer.GetCustomerOrders());
        Assert.NotEqual(_customer, _order.GetCreatedByCustomer());
        
    }

    [Fact]
    public void UpdateCustomerOrderTest()
    {
        _order.AddToCustomer(_customer);
        _order.UpdateCustomerOrder("NewOrderId");
        
        Assert.Contains(_customer.GetCustomerOrders(), 
            order => order.OrderId.Equals("NewOrderId"));
    }
}   