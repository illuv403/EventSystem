using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class StandardExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var standard = TestData.Standard();

        Assert.Single(Standard.StandardList);
        Assert.Equal(standard, Standard.StandardList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Standard.ClearExtent();
        
        var standard = TestData.Standard();

        var newList = new List<Standard>
        {
            new(standard.GateNumber, standard.Price, "L-1", standard.EventForTicket, standard.Order)
        };
        
        Standard.LoadExtent(newList);
        
        Assert.Single(Standard.StandardList);
        Assert.Equal("L-1", Standard.StandardList[0].SeatNumber);
    }
}