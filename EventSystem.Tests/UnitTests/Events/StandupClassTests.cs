using EventSystem.Classes;

namespace EventSystem.Tests;

public class StandupClassTests
{
    private Standup _standup = new("Rory Scovel", "Unpredictability", true, 18);
    
    [Fact]
    public void StandupCreationTest()
    {
        Assert.Equal("Rory Scovel", _standup.Comedian);
        Assert.Equal("Unpredictability", _standup.ComedyStyle);
        Assert.True(_standup.IsMatureContent);
        Assert.Equal(18, _standup.MinimumAge);
    }
}
