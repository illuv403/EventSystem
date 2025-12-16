using EventSystem.Classes;

namespace EventSystem.Tests;

public class StadiumClassTests
{
    public Stadium _stadium = new Stadium(100000, "Al. Wilanowska 12", new List<Event>());
    
    [Fact]
    public void StadiumCreationTest()
    {
        Assert.Equal(100000, _stadium.Capacity);
        Assert.Equal("Al. Wilanowska 12", _stadium.Address);
        Assert.Equal(new List<Event>(), _stadium.EventsAssigned);
    }
}