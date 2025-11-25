using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class FanZoneExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var fanzone = TestData.FanZone();

        Assert.Single(FanZone.FanZoneList);
        Assert.Equal(fanzone, FanZone.FanZoneList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        FanZone.ClearExtent();
        
        var fanzone = TestData.FanZone();
        
        var newList = new List<FanZone>
        {
            new("E6", fanzone.Price, fanzone.EventForTicket, fanzone.Order)
        };
        
        FanZone.LoadExtent(newList);
        
        Assert.Single(FanZone.FanZoneList);
        Assert.Equal("E6", FanZone.FanZoneList[0].GateNumber);
    }
}