namespace EventSystem.Classes;

public class Stadium : Location
{
    private static readonly List<Stadium> _stadiumList = [];
    public static IReadOnlyList<Stadium> StadiumList => _stadiumList;
    
    public Stadium(int capacity, string address , List<Event> eventsAssigned) 
        : base(capacity, address, eventsAssigned)
    {
        _stadiumList.Add(this);
    }

    public Stadium() : base()
    {
    }
    
    public static void LoadExtent(List<Stadium>? list)
    {
        _stadiumList.Clear();
        
        if(list != null)
            _stadiumList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _stadiumList.Clear();   
    }
}