using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class SceneExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var scene = TestData.Scene();
        
        Assert.Single(Scene.SceneList);
        Assert.Equal(scene, Scene.SceneList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        Scene.ClearExtent();
        
        var scene = TestData.Scene();

        var newList = new List<Scene>
        {
            new(scene.Capacity, "Miami Street 9/10", scene.EventsAssigned)
        };
        
        Scene.LoadExtent(newList);

        Assert.Single(Scene.SceneList);
        Assert.Equal("Miami Street 9/10", Scene.SceneList[0].Address);
    }
}