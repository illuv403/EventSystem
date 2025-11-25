namespace EventSystem.Classes;

public class Club : Location
{
    private static readonly List<Club> _clubList = [];
    public static IReadOnlyList<Club> ClubList => _clubList;

    public Club(int capacity, string address, List<Event> eventsAssigned) 
        : base(capacity, address , eventsAssigned)
    {
        _clubList.Add(this);
    }
    
    public Club() : base() { }
    
    public static void LoadExtent(List<Club>? list)
    {
        _clubList.Clear();
        
        if(list != null)
            _clubList.AddRange(list);
    }

    public static void ClearExtent()
    {
        _clubList.Clear();
    }
}