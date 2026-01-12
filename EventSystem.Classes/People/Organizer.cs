using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Organizer : Person , IDisposable
{
    
    private bool _isDisposed;
    
    private static readonly List<Organizer> _organizerList = [];
    public static IReadOnlyList<Organizer> OrganizerList => _organizerList;
    
    public decimal Profit { get; set; }
    
    [JsonInclude]
    public List<Staff> Staff { get; private set; }
    
    [JsonInclude]
    public List<Event> Events { get; private set; }
    
    private HashSet<Event> _assignedEvents = new();
    private HashSet<Hiring> _hiringHistory = new();
    public Organizer(string name, string surname, string email, string phoneNumber, DateOnly birthDate, decimal profit,  List<Staff> staff, List<Event> events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Profit = profit;
        
        Staff = staff;
        
        foreach (var eventToAdd in events)
        {
            AddAssignedEvent(eventToAdd);
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
    
    public HashSet<Hiring> GetHiringHistory() => [.._hiringHistory];

    public void AddHiring(Hiring hiring)
    {
        if (_hiringHistory.Contains(hiring)) return;
        
        _hiringHistory.Add(hiring);
    }

    public void RemoveHiring(Hiring hiring)
    {
        if (!_hiringHistory.Contains(hiring)) return;
        
        _hiringHistory.Remove(hiring);
        hiring.Dispose();
    }
    
    public HashSet<Event> GetAssignedEvents()
    {
        return [.._assignedEvents];
    }

    public void AddAssignedEvent(Event eventToAdd)
    {
        if (_assignedEvents.Contains(eventToAdd))  return;
        
        _assignedEvents.Add(eventToAdd);
        eventToAdd.AddEventOrganizer(this);
        
    }

    public void RemoveAssignedEvent(Event eventToRemove)
    {
        if (!_assignedEvents.Contains(eventToRemove))  return;
        
        _assignedEvents.Remove(eventToRemove);
        eventToRemove.RemoveEventOrganizer(this);
    }

    public void UpdateAssignedEvents(Event eventToRemove, Event eventToAdd)
    {
        RemoveAssignedEvent(eventToRemove);
        AddAssignedEvent(eventToAdd);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;
        _isDisposed = true;

        if (disposing)
        {
            _organizerList.Remove(this);
            foreach (var staff  in Staff)
            {
                Staff.Remove(staff);
                staff.Organizer = null;
            }

            foreach (var eventInSet in Events)
            {
                RemoveAssignedEvent(eventInSet);
                eventInSet.RemoveEventOrganizer(this);
                eventInSet.Organizers.Remove(this);
            }

            foreach (var eventInSet in _assignedEvents)
            {
                RemoveAssignedEvent(eventInSet);
                eventInSet.RemoveEventOrganizer(this);
                eventInSet.Organizers.Remove(this);
            }

            foreach (var hiring in _hiringHistory)
            {
                hiring.Organizer.RemoveHiring(hiring);
                hiring.Staff.Organizer = null;
                _hiringHistory.Remove(hiring);
            }
        }
    }
    
    public Staff ChangeToStaff(Staff.StaffRole role,
        Address address, decimal salary, List<Event> events, Organizer organizer, DateOnly hireDate, Staff? manager, 
        List<Staff> subordinates)
    {
        
        Staff changedStaff = new Staff(Name,  Surname, Email, PhoneNumber, BirthDate, role, address, salary, events, organizer,
            hireDate, manager, subordinates);
        Dispose();
        return changedStaff;
    }

    public Customer ChangeToCustomer(List<Order> orders)
    {
        Customer changedCustomer = new Customer(Name,  Surname, Email, PhoneNumber, BirthDate, orders);
        Dispose();
        return changedCustomer;
    }
    
}