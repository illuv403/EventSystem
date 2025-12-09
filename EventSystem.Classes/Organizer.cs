using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Organizer : Person
{
    private static readonly List<Organizer> _organizerList = [];
    public static IReadOnlyList<Organizer> OrganizerList => _organizerList;
    
    public decimal Profit { get; set; }
    
    [JsonInclude]
    public List<Staff> Staff { get; private set; }
    
    [JsonInclude]
    public List<Event> Events { get; private set; }
    
    private HashSet<Event> _eventsResponsibleFor = new();
    public Organizer(string name, string surname, string email, string phoneNumber, DateOnly birthDate, decimal profit,  List<Staff> staff, List<Event> events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Profit = profit;
        
        Staff = staff;
        
        if (events.Count != 0)
        {
            foreach (var eventToAdd in events)
            {
                AddToEventsResponsibleFor(eventToAdd);
            }
        }
        Events = events;
        
        _organizerList.Add(this);
    }

    public Organizer() : base()
    {
    }
    
    public static void LoadExtent(List<Organizer>? list)
    {
        _organizerList.Clear();
        if(list != null) _organizerList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _organizerList.Clear();   
    }
    
    public HashSet<Event> GetEventsResponsibleFor()
    {
        return [.._eventsResponsibleFor];
    }

    public void AddToEventsResponsibleFor(Event eventToAdd)
    {
        if (_eventsResponsibleFor.Contains(eventToAdd))  return;
        
        _eventsResponsibleFor.Add(eventToAdd);
        eventToAdd.AddResponsibleForEvent(this);
    }

    public void RemoveInEventsResponsibleFor(Event eventToRemove)
    {
        if (!_eventsResponsibleFor.Contains(eventToRemove))  return;
        
        _eventsResponsibleFor.Remove(eventToRemove);
        eventToRemove.RemoveResponsibleForEvent(this);
    }

    public void UpdateInEventsResponsibleFor(Event eventToRemove, Event eventToAdd)
    {
        RemoveInEventsResponsibleFor(eventToRemove);
        AddToEventsResponsibleFor(eventToAdd);
    }
}