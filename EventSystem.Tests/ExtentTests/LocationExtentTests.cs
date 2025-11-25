using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class LocationExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var location = TestData.Location();
        
        Assert.Single(Location.LocationList);
        Assert.Equal(location, Location.LocationList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Location.ClearExtent();
        
        var location = TestData.Location();
        
        var newList = new List<Location>
        {
            new(location.Capacity, "Main Street 43/12", location.EventsAssigned)
        };
        
        Location.LoadExtent(newList);
        
        Assert.Single(Location.LocationList);
        Assert.Equal("Main Street 43/12", Location.LocationList[0].Address);
    }
}