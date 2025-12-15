using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public class Location
{
    private static readonly List<Location> _locationList = [];
    public static IReadOnlyList<Location> LocationList => _locationList;
    
    public int Capacity { get; set; }
    public string Address { get; set; }

    [JsonInclude]
    public List<Event> EventsAssigned { get; private set; }
    
    private HashSet<Event> _eventsAssigned = new();
    
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

        foreach (var eventAssigned in _eventsAssigned)
        {
            AddEvent(eventAssigned);
        }
        
        _locationList.Add(this);
    }

    public Location() { }

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

    public HashSet<Event> GetEventsAssigned()
    {
        return [.._eventsAssigned];
    }

    public void AddEvent(Event newEvent)
    {
        if (_eventsAssigned.Contains(newEvent)) return;
        
        _eventsAssigned.Add(newEvent);
    }

    public void RemoveEvent(Event newEvent)
    {
        if (!_eventsAssigned.Contains(newEvent)) return;
        
        _eventsAssigned.Remove(newEvent);
    }
    
    public void UpdateEvent(Event newEvent)
    {
        if (newEvent.GetLocation() == this)
            return;

        var location = newEvent.GetLocation();
        
        location.RemoveEvent(newEvent);
        AddEvent(newEvent);
    }
    
}