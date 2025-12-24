namespace EventSystem.Classes;

public class Standup
{
    private static readonly List<Standup> _standupList = [];
    public static IReadOnlyList<Standup> StandupList => _standupList;
    
    public Standup() 
    {
        _standupList.Add(this);
    }
    
    public static void LoadExtent(List<Standup>? list)
    {
        _standupList.Clear();
        
        if(list != null)
            _standupList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _standupList.Clear();   
    }
}