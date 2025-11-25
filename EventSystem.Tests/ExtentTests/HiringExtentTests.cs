using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class HiringExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var hiring = TestData.Hiring();

        Assert.Single(Hiring.List);
        Assert.Equal(hiring, Hiring.List[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var hiring = TestData.Hiring();

        var newList = new List<Hiring>
        {
            new(hiring.Staff, hiring.Organizer, new DateOnly(2025, 06, 23), hiring.DateFired)
        };
        
        Hiring.LoadExtent(newList);
        
        Assert.Single(Hiring.List);
        Assert.Equal(new DateOnly(2025, 06, 23), Hiring.List[0].DateHired);
    }
}