using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class AddressExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var addr = TestData.Address();
        
        Assert.Single(Address.AddressList);
        Assert.Equal(addr, Address.AddressList[0]);
    }

    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Address.ClearExtent();
        
        var addr = TestData.Address();

        var newList = new List<Address>
        {
            new("Spain", addr.City, addr.Street, addr.AppNumber, addr.Index, addr.Staff)
        };
        
        Address.LoadExtent(newList);
        
        Assert.Single(Address.AddressList);
        Assert.Equal("Spain", Address.AddressList[0].Country);
    }
}