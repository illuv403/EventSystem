namespace EventSystem.Classes;

public class Scene : Location
{
    private static readonly List<Scene> _sceneList = [];
    public static IReadOnlyList<Scene> SceneList => _sceneList;
    
    public Scene(int capacity, string address, List<Event> eventsAssigned) 
        : base(capacity, address, eventsAssigned)
    {
        _sceneList.Add(this);
    }
}