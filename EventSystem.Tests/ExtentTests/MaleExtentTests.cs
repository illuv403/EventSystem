using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class MaleExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var male = TestData.Male();
        
        Assert.Single(Male.List);
        Assert.Equal(male, Male.List[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var male = TestData.Male();
        
        var newList = new List<Male>
        {
            new("Antonio", male.Surname, male.Email, male.PhoneNumber, male.BirthDate)
        };
        
        Male.LoadExtent(newList);
        
        Assert.Single(Male.List);
        Assert.Equal("Antonio", Male.List[0].Name);
    }
}