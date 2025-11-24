using EventSystem.Classes;

namespace EventSystem.Tests;

public class MaleClassTests
{
    private Male _male = new Male("Henry", "Grey", 
        "test@gmail.com", "+48573370352",
        new DateOnly(2000, 1, 1));
    
    [Fact]
    public void MaleCreationTest()
    {
        Assert.Equal("Henry", _male.Name);
        Assert.Equal("Grey", _male.Surname);
        Assert.Equal("test@gmail.com",  _male.Email);
        Assert.Equal("+48573370352", _male.PhoneNumber);
        Assert.Equal(new DateOnly(2000, 1, 1), _male.BirthDate);
        Assert.Equal('\u2642', _male.GetSymbol());
    }
}