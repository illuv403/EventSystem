using System.Xml.Serialization;

namespace EventSystem.Classes;

[XmlInclude(typeof(Club))]
[XmlInclude(typeof(Stadium))]
[XmlInclude(typeof(Scene))]
public class Location
{
    private static readonly List<Location> _locationList = [];
    public static IReadOnlyList<Location> LocationList => _locationList;
    
    public int Capacity { get; }
    public string Address { get; }

    [XmlIgnore]
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

    public Location()
    {
        EventsAssigned = new List<Event>();
    }

    public static void LoadExtent(List<Location>? list)
    {
        _locationList.Clear();
        
        if(list != null)
            _locationList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _locationList.Clear();   
    }
}