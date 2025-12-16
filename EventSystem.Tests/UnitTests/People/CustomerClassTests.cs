using System.Dynamic;
using EventSystem.Classes;
using NuGet.Frameworks;

namespace EventSystem.Tests;

public class CustomerClassTests
{
    private Customer _customer;

    private Event _event1;
    private Event _event2;

    private Order _order;

    public CustomerClassTests()
    {
        _customer = new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        );
        
        _event1 = new Event("New Event", new DateTime(2025, 12, 27), new DateTime(2025, 12, 30), "New event",
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

        _order = new("SomeOrderId", _customer, new List<Ticket>());
    }
    
    [Fact]
    public void CustomerCreationTest()
    {
        Assert.Equal("Henry", _customer.Name);
        Assert.Equal("Grey", _customer.Surname);
        Assert.Equal("test@gmail.com",  _customer.Email); 
        Assert.Equal("+48573370352", _customer.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _customer.BirthDate);
        Assert.Equal(new List<Order>(),  _customer.Orders);
        Assert.Equal(25, _customer.Age);
        Assert.Equal(Customer.CustomerStatus.Active, _customer.Status);
    }
    
    [Fact]
    public void CustomerNameNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Name cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void CustomerSurnameNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "", "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Surname cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void CustomerEmailNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "Grey", "", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Email cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void CustomerEmailInvalidTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "Grey", "sadasdada123--=!112mas@@dad", "+48573370352",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Invalid email address.", ex.Message);
    }
    
    [Fact]
    public void CustomerPhoneNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "Grey", "test@gmail.com", "",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Phone number cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void CustomerPhoneInvalidTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "Grey", "test@gmail.com", "213asda",
            new DateOnly(2000, 1, 1), new List<Order>()
        ));
        Assert.Equal("Phone number is invalid.", ex.Message);
    }
    
    [Fact]
    public void CustomerBirthDateInvalidTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Customer("Henry",
            "Grey", "test@gmail.com", "+48573370352",
            new DateOnly(2027, 1, 1), new List<Order>()
        ));
        Assert.Equal("Birth date is invalid.", ex.Message);
    }

    [Fact]
    public void AddCustomerEventTest()
    {
        _customer.AddWishForEvent(_event1);

        Assert.Contains(_event1, _customer.WishesForEvent());
        Assert.Contains(_customer, _event1.GetInWhoseWishList());
    }

    [Fact]
    public void RemoveCustomerEventTest()
    {
        _customer.RemoveWishForEvent(_event1);
        
        Assert.DoesNotContain(_customer, _event1.GetInWhoseWishList());
        Assert.DoesNotContain(_event1, _customer.WishesForEvent());
    }

    [Fact]
    public void UpdateCustomerEventTest()
    {
        _customer.AddWishForEvent(_event1);
        _customer.UpdateWishesForEvent(_event1, _event2);
        
        Assert.DoesNotContain(_event1, _customer.WishesForEvent());
        Assert.Contains(_event2, _customer.WishesForEvent());
        
        Assert.DoesNotContain(_customer, _event1.GetInWhoseWishList());
        Assert.Contains(_customer, _event2.GetInWhoseWishList());
    }
    
    // Order //
    [Fact]
    public void AddOrderTest()
    {
        _customer.AddCustomerOrder(_order);
        
        Assert.Contains(_order, _customer.GetCustomerOrders());
        Assert.Equal(_customer, _order.GetCreatedByCustomer()); 
    }

    [Fact]
    public void RemoveOrderTest()
    {
        _customer.RemoveCustomerOrder(_order);
        
        Assert.DoesNotContain(_order, _customer.GetCustomerOrders());
    }

    [Fact]
    public void UpdateOrderTest()
    {
        _customer.UpdateCustomerOrder("SomeOrderId", "NewOrderId", _order);
        
        Assert.Contains(_customer.GetCustomerOrders(), 
            order => order.OrderId.Equals(_order.OrderId));
                
    }
}