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
    
    private HashSet<Event> _assignedEvents = new();
    private HashSet<Staff> _hiredStaff = new();
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
    
    public void AddHiredStaff(Staff staffToAdd, DateOnly dateHired, DateOnly? dateFired)
    {
        if (_hiredStaff.Contains(staffToAdd)) return;
        _hiredStaff.Add(staffToAdd);
        staffToAdd.UpdateHiredByWho(this, dateHired, dateFired);
        AddNewHiringToHiringHistory(this, staffToAdd, dateHired, dateFired);
    }

    public void RemoveHiredStaff(Staff staffToRemove, DateOnly dateFired)
    {
        if (!_hiredStaff.Contains(staffToRemove))  return;
        _hiredStaff.Remove(staffToRemove);
        staffToRemove.RemoveHiredByWho(this, dateFired);
        UpdateFireDateInHiringHistory(this, staffToRemove, dateFired);
    }

    public void UpdateHiredByWho(Staff staffToRemove, Event staffToAdd, DateOnly dateFired)
    {
        RemoveHiredStaff(staffToRemove, dateFired);
        AddAssignedEvent(staffToAdd);
    }

    public void AddNewHiringToHiringHistory(Organizer organizerToAdd, Staff staffToAdd, DateOnly dateHired, DateOnly? dateFired)
    {
        Hiring newHiring = new Hiring(staffToAdd, organizerToAdd, dateHired, dateFired);
        if (_hiringHistory.Contains(newHiring))
        {
            return;
        }
        
        _hiringHistory.Add(newHiring);
        staffToAdd.AddNewHiringToHiringHistory(newHiring);
    }

    public void UpdateFireDateInHiringHistory(Organizer organizerToEdit, Staff staffToEdit, DateOnly dateFired)
    {
        foreach (Hiring hiring in _hiringHistory)
        {
            if (dateFired.Equals(hiring.DateFired))
            {
                return;
            }
            
            if (hiring.Organizer == organizerToEdit && hiring.Staff == staffToEdit)
            {
                hiring.DateFired = dateFired;
            }
        }
        staffToEdit.UpdateFireDateInHiringHistory(organizerToEdit, staffToEdit, dateFired);
    }
    
    //Probably Will be needed later
    /*
    public void RemoveItemFromHiringHistory(Hiring hiringToRemove)
    {
        if (!(_hiringHistory.Contains(hiringToRemove))) return;
        hiringToRemove.Staff.RemoveFromHiringHistory(hiringToRemove);
        _hiringHistory.Remove(hiringToRemove);
    }*/
}