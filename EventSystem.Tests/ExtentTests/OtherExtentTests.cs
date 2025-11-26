using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class OtherExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var other = TestData.Other();

        Assert.Single(Other.OtherList);
        Assert.Equal(other, Other.OtherList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Other.ClearExtent();
        
        var other = TestData.Other();
        
        var newList = new List<Other>
        {
            new(other.Name, other.Surname, other.Email, other.PhoneNumber, other.BirthDate, "YQU")
        };
        
        Other.LoadExtent(newList);
        
        Assert.Single(Other.OtherList);
        Assert.Equal("YQU", Other.OtherList[0].Type);  
    }
}