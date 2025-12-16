using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class ClubExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var club = TestData.Club();

        Assert.Single(Club.ClubList);
        Assert.Equal(club, Club.ClubList[0]);
    }

    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var club = TestData.Club();

        var newList = new List<Club>
        {
            new(256, club.Address, club.EventsAssigned)
        };
        
        Club.LoadExtent(newList);
        
        Assert.Single(Club.ClubList);
        Assert.Equal(256, Club.ClubList[0].Capacity);
    }
}