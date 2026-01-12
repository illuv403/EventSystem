using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class SportExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var sport = TestData.Sport();
        
        Assert.Single(Sport.SportList);
        Assert.Equal(sport, Sport.SportList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var sport = TestData.Sport();
        
        var newList = new List<Sport>
        {
            new("Arsenal", "Liverpool", "Premier League", "Football")
        };
        
        Sport.LoadExtent(newList);
        
        Assert.Single(Sport.SportList);
        Assert.Equal("Premier League", Sport.SportList[0].League);
    }
}