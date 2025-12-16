using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class OrganizerExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var organizer = TestData.Organizer();
        
        Assert.Single(Organizer.OrganizerList);
        Assert.Equal(organizer, Organizer.OrganizerList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var organizer = TestData.Organizer();
        
        var newList = new List<Organizer>
        {
            new("Karolina", organizer.Surname, organizer.Email, organizer.PhoneNumber, organizer.BirthDate, organizer.Profit, organizer.Staff, organizer.Events)
        };
        
        Organizer.LoadExtent(newList);

        Assert.Single(Organizer.OrganizerList);
        Assert.Equal("Karolina", Organizer.OrganizerList[0].Name);
    }
}