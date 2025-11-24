using EventSystem.Classes;

namespace EventSystem.Tests;

public class CustomerClassTests
{
    private Customer _customer = new Customer("Henry",
        "Grey", "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1), new List<Order>()
    );

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
}