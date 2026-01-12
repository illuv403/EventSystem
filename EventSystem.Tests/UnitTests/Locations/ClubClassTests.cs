using EventSystem.Classes;

namespace EventSystem.Tests;

public class ClubClassTests
{
    public Club _club = new Club(10000, "Al. Wilanowska 12", new List<Event>());
    
    [Fact]
    public void ClubCreationTest()
    {
        Assert.Equal(10000, _club.Capacity);
        Assert.Equal("Al. Wilanowska 12", _club.Address);
        Assert.Equal(new List<Event>(), _club.EventsAssigned);
    }
}