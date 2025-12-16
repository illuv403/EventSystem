using EventSystem.Classes;

namespace EventSystem.Tests;

public class SceneClassTests
{
    public Scene _scene = new Scene(10000, "Al. Wilanowska 12", new List<Event>());
    
    [Fact]
    public void SceneCreationTest()
    {
        Assert.Equal(10000, _scene.Capacity);
        Assert.Equal("Al. Wilanowska 12", _scene.Address);
        Assert.Equal(new List<Event>(), _scene.EventsAssigned);
    }
}