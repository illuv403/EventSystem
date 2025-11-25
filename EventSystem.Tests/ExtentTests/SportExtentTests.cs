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
            new("Sport Event #2", sport.StartDateAndTime, sport.EndDateAndTime, sport.Description, sport.Organizers, sport.StaffAssigned, sport.InWhoseWishList, sport.Location, sport.TicketsForEvent)
        };
        
        Sport.LoadExtent(newList);
        
        Assert.Single(Sport.SportList);
        Assert.Equal("Sport Event #2", Sport.SportList[0].Title);
    }
}