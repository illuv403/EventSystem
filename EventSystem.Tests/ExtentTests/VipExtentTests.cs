using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class VipExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var vip = TestData.Vip();

        Assert.Single(Vip.VipList);
        Assert.Equal(vip, Vip.VipList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Vip.ClearExtent();
        
        var vip = TestData.Vip();

        var newList = new List<Vip>
        {
            new("U719", vip.Price, vip.LoungeNumber, vip.EventForTicket, vip.Order)
        };
        
        Vip.LoadExtent(newList);
        
        Assert.Single(Vip.VipList);
        Assert.Equal("U719", Vip.VipList[0].GateNumber);
    }
}