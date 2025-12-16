using EventSystem.Classes;

namespace EventSystem.Tests;

public class OtherClassTests
{
    private Other _other = new Other("Henry", "Grey", 
        "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1), "None");

    [Fact]
    public void OtherCreationTest()
    {
        Assert.Equal("Henry", _other.Name);
        Assert.Equal("Grey", _other.Surname);
        Assert.Equal("test@gmail.com",  _other.Email);
        Assert.Equal("+48573370352", _other.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _other.BirthDate);
        Assert.Equal("None", _other.Type);
    }
}