using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class OrderExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var order = TestData.Order();

        Assert.Single(Order.List);
        Assert.Equal(order, Order.List[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Order.ClearExtent();
        
        var order = TestData.Order();
        
        var newList = new List<Order>
        {
            new(new Customer(order.CreatedByCustomer.Name, order.CreatedByCustomer.Surname,
                "mm.mari@gmail.com", order.CreatedByCustomer.PhoneNumber, order.CreatedByCustomer.BirthDate, order.CreatedByCustomer.Orders), order.TicketsInOrder)
        };
        
        Order.LoadExtent(newList);
        
        Assert.Single(Order.List);
        Assert.Equal("mm.mari@gmail.com", Order.List[0].CreatedByCustomer.Email);
    }
}