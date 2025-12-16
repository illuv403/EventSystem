using EventSystem.Classes;

namespace EventSystem.Tests;

public class FemaleClassTests
{
    private Female _female = new Female("Anne", "Grey", 
        "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1));
    
    [Fact]
    public void FemaleCreationTest()
    {
        Assert.Equal("Anne", _female.Name);
        Assert.Equal("Grey", _female.Surname);
        Assert.Equal("test@gmail.com",  _female.Email);
        Assert.Equal("+48573370352", _female.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _female.BirthDate);
        Assert.Equal('\u2640', _female.GetSymbol());
    }
}