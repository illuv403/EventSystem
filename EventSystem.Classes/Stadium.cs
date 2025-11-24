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
}