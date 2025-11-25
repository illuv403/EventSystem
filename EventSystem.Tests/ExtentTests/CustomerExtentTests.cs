using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class CustomerExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var customer = TestData.Customer();
        
        Assert.Single(Customer.CustomerList);
        Assert.Equal(customer, Customer.CustomerList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var customer = TestData.Customer();

        var newList = new List<Customer>
        {
            new("Michael", customer.Surname, 
                         customer.Email, customer.PhoneNumber, 
                         customer.BirthDate, customer.Orders)
        };
        
        Customer.LoadExtent(newList);
        
        Assert.Single(Customer.CustomerList);
        Assert.Equal("Michael", Customer.CustomerList[0].Name);
    }
}