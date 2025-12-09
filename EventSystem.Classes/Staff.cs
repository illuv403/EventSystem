using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Staff : Person
{
    private static readonly List<Staff> _staffList = [];
    public static IReadOnlyList<Staff> StaffList => _staffList;
    
    public enum StaffRole 
    {
        Security,
        Cleaner,
        Bartender,
        Stagehand,
        Cameramen,
        Manager
    }
    public StaffRole Role { get; set; }
    [JsonInclude]
    public Address Address { get; private set; }
    public decimal Salary { get; set; }
    
    [JsonInclude]
    public Staff? Manager { get; private set; }
    
    [JsonInclude]
    public List<Staff> Subordinates { get; private set; }
    
    [JsonInclude]
    public List<Event> Events { get; private set; }
    
    [JsonInclude]
    public Organizer Organizer { get; private set; }

    private HashSet<Event> _assignedEvents = new();
    private HashSet<Staff> _staffInCharge = new();
    
    public Staff(string name, string surname, string email, string phoneNumber, DateOnly birthDate, StaffRole role,
        Address address, decimal salary, List<Event> events, Organizer organizer, Staff? manager, List<Staff> subordinates)
        : base(name, surname, email, phoneNumber, birthDate)
    {
        if (salary < 0)
            throw new ArgumentException("Salary cannot be negative");
        
        Role = role;
        Address = address;
        Salary = salary;
        
        if (events.Count != 0)
        {
            foreach (var eventToAdd in events)
            {
                AddAssignedEvent(eventToAdd);
            }
        }
        Events = events;
        Organizer = organizer;
        Manager = manager;
        if (subordinates.Count != 0)
        {
            foreach (var subordinate in subordinates)
            {
                if(subordinate != this || (Role == StaffRole.Manager && subordinate.Role != StaffRole.Manager))
                {
                    AddStaffInCharge(subordinate);
                }
            }
        }
        Subordinates = subordinates;
        
        _staffList.Add(this);
    }

    public Staff() { }
    
    public static void LoadExtent(List<Staff>? list)
    {
        _staffList.Clear();
        
        if(list != null)
            _staffList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _staffList.Clear();   
    }

    public HashSet<Event> GetAssignedEvents()
    {
        return [.._assignedEvents];
    }

    public void AddAssignedEvent(Event eventToAssign)
    {
        if (_assignedEvents.Contains(eventToAssign)) return;
        
        
        _assignedEvents.Add(eventToAssign);
        eventToAssign.AddStaffAssigned(this);
    }

    public void RemoveAssignedEvent(Event eventToRemove)
    {
        if (!_assignedEvents.Contains(eventToRemove)) return;
        
        _assignedEvents.Remove(eventToRemove);
        eventToRemove.RemoveStaffAssigned(this);
    }
    
    public void UpdateAssignedEvent(Event eventToRemove, Event eventToAssign) {
        RemoveAssignedEvent(eventToRemove);
        AddAssignedEvent(eventToAssign);
    }
    
    
    public HashSet<Staff> GetStaffInCharge()
    {
        return [.._staffInCharge];
    }

    public void AddStaffInCharge(Staff staffToAssign)
    {
        if (_staffInCharge.Contains(staffToAssign)) return;

        if (staffToAssign == this)
        {
            throw new ArgumentException($"Staff can not be assigned to itself.");
        }
        if(Role == StaffRole.Manager && staffToAssign.Role == StaffRole.Manager)
        {
            throw new ArgumentException($"Manager can not be in charge of another manager.");
        }
        
        _staffInCharge.Add(staffToAssign);
        staffToAssign.Manager = this;
    }

    public void RemoveStaffInCharge(Staff staffToRemove)
    {
        if (!_staffInCharge.Contains(staffToRemove)) return;
        
        _staffInCharge.Remove(staffToRemove);
        staffToRemove.Manager = null;
    }
    
    
    public void UpdateStaffInCharge(Staff staffToRemove, Staff staffToAssign) {
        RemoveStaffInCharge(staffToRemove);
        AddStaffInCharge(staffToAssign);
    }
}