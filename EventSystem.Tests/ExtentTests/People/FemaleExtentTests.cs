using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class FemaleExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var female = TestData.Female();

        Assert.Single(Female.List);
        Assert.Equal(female, Female.List[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var female = TestData.Female();

        var newList = new List<Female>
        {
            new("Asia", female.Surname, female.Email, female.PhoneNumber, female.BirthDate)
        };
        
        Female.LoadExtent(newList);
        
        Assert.Single(Female.List);
        Assert.Equal("Asia", Female.List[0].Name);
    }
}