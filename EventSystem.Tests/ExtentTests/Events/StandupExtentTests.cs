using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class StandupExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var standup = TestData.Standup();

        Assert.Single(Standup.StandupList);
        Assert.Equal(standup, Standup.StandupList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var standup = TestData.Standup();

        var newList = new List<Standup>
        {
            new("Rory Scovel", "Unpredictability", true, 18)
        };
        
        Standup.LoadExtent(newList);
        
        Assert.Single(Standup.StandupList);
        Assert.Equal("Unpredictability", Standup.StandupList[0].ComedyStyle);
    }
}