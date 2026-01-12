using EventSystem.Classes;

namespace EventSystem.Tests;

public class SportClassTests
{
    private Sport _sport = new("Arsenal", "Liverpool", "Premier League", "Football");
    
    [Fact]
    public void SportCreationTest()
    {
        Assert.Equal("Arsenal", _sport.HomeTeam);
        Assert.Equal("Liverpool", _sport.AwayTeam);
        Assert.Equal("Premier League", _sport.League);
        Assert.Equal("Football", _sport.SportType);
    }
}