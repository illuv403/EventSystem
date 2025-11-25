using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class StadiumExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var stadium = TestData.Stadium();

        Assert.Single(Stadium.StadiumList);
        Assert.Equal(stadium, Stadium.StadiumList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var stadium = TestData.Stadium();

        var newList = new List<Stadium>
        {
            new(1109, stadium.Address, stadium.EventsAssigned)
        };
        
        Stadium.LoadExtent(newList);
        
        Assert.Single(Stadium.StadiumList);
        Assert.Equal(1109, Stadium.StadiumList[0].Capacity);
    }
}