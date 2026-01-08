namespace EventSystem.Classes;

public class Sport
{
    private static readonly List<Sport> _sportList = [];
    public static IReadOnlyList<Sport> SportList => _sportList;
    
    public Sport() 
    
    {
        _sportList.Add(this);
    }
    
    public static void LoadExtent(List<Sport>? list)
    {
        _sportList.Clear();
        
        if(list != null)
            _sportList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _sportList.Clear();   
    }
}