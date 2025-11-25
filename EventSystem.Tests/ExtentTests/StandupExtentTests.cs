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
        Standup.ClearExtent();
        
        var standup = TestData.Standup();

        var newList = new List<Standup>
        {
            new("Standup #2", standup.StartDateAndTime, standup.EndDateAndTime, standup.Description, standup.Organizers, standup.StaffAssigned, standup.InWhoseWishList, standup.Location, standup.TicketsForEvent)
        };
        
        Standup.LoadExtent(newList);
        
        Assert.Single(Standup.StandupList);
        Assert.Equal("Standup #2", Standup.StandupList[0].Title);
    }
}