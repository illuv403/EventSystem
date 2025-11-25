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

    public Scene() : base()
    {
    }
    
    public static void LoadExtent(List<Scene>? list)
    {
        _sceneList.Clear();
        
        if(list != null)
            _sceneList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _sceneList.Clear();   
    }
}