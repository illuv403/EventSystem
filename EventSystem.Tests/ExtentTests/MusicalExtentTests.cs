using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class MusicalExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var musical = TestData.Musical();

        Assert.Single(Musical.MusicalList);
        Assert.Equal(musical, Musical.MusicalList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Musical.ClearExtent();
        
        var musical = TestData.Musical();
        
        var newList = new List<Musical>
        {
            new("MyMusical", musical.StartDateAndTime, musical.EndDateAndTime, musical.Description, musical.Organizers, musical.StaffAssigned, musical.InWhoseWishList, musical.Location, musical.TicketsForEvent)
        };
        
        Musical.LoadExtent(newList);

        Assert.Single(Musical.MusicalList);
        Assert.Equal("MyMusical", Musical.MusicalList[0].Title);
    }
}