using EventSystem.Classes;

namespace EventSystem.Tests;

public class MusicalClassTests
{
    private Musical _musical = new("John Polow", "Pop Musical");
    
    [Fact]
    public void MusicalCreationTest()
    {
        Assert.Equal("John Polow", _musical.Artist);
        Assert.Equal("Pop Musical", _musical.Genre);
    }
}