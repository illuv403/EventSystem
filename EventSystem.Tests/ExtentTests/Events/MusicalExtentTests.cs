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
        var musical = TestData.Musical();
        
        var newList = new List<Musical>
        {
            new("John Polow", "Pop Musical")
        };
        
        Musical.LoadExtent(newList);

        Assert.Single(Musical.MusicalList);
        Assert.Equal("John Polow", Musical.MusicalList[0].Artist);
    }
}