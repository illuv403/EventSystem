namespace EventSystem.Classes;

public class Location
{
    private static readonly List<Location> _locationList = [];
    public static IReadOnlyList<Location> LocationList => _locationList;
    
    public int Capacity { get; }
    public string Address { get; }

    public List<Event> EventsAssigned { get; }

    public Location(int capacity, string address,  List<Event> eventsAssigned)
    {
        if (capacity < 1)
            throw new ArgumentException("Capacity cannot be less than 1.");
        
        address = address.Trim();
        
        if (string.IsNullOrWhiteSpace(address))
            throw new ArgumentException("Address cannot be empty.");
        
        Capacity = capacity;
        Address = address;
        EventsAssigned = eventsAssigned;
        
        _locationList.Add(this);
    }
}