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
    private HashSet<Hiring> _hiringHistory = new();
    private Address _accommodationAddress;
    private Organizer _hiredByWho;
    
    
    public Staff(string name, string surname, string email, string phoneNumber, DateOnly birthDate, StaffRole role,
        Address address, decimal salary, List<Event> events, Organizer organizer, Staff? manager, List<Staff> subordinates)
        : base(name, surname, email, phoneNumber, birthDate)
    {
        if (salary < 0) throw new ArgumentException("Salary cannot be negative");
        
        Role = role;
        Address = address;
        Salary = salary;
        foreach (var eventToAdd in events) 
        { 
            AddAssignedEvent(eventToAdd);
        }
        
        Events = events;
        Organizer = organizer;
        Manager = manager;
        foreach (var subordinate in subordinates)
        {
            AddStaffInCharge(subordinate);
        }
        
        Subordinates = subordinates;

        _accommodationAddress = address;
        address.AddStaffLivingHere(this);
        _hiredByWho = organizer;
        
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
    
    
    //Should be changed if Address in Staff CAN be null

    public void AddAccommodationAddress(Address newAccommodationAddress)
    {
        if (_accommodationAddress.Equals(newAccommodationAddress)) return;
        
        _accommodationAddress = newAccommodationAddress;
        newAccommodationAddress.AddStaffLivingHere(this);
    }

    public void UpdateAccommodationAddress(Address oldAccommodationAddress, Address newAccommodationAddress)
    {
        if (_accommodationAddress.Equals(newAccommodationAddress)) return;
        
        oldAccommodationAddress.RemoveStaffLivingHere(this, newAccommodationAddress);
        newAccommodationAddress.AddStaffLivingHere(this);
    }
    
    
    public void UpdateHiredByWho(Organizer hirerToAdd,  DateOnly dateHired, DateOnly? dateFired)
    {
        if (_hiredByWho.Equals(hirerToAdd)) return;
        
        _hiredByWho.AddHiredStaff(this, dateHired, dateFired);
        _hiredByWho = hirerToAdd;
    }

    public void RemoveHiredByWho(Organizer hirerToRemove, DateOnly dateFired)
    {
        if (!_hiredByWho.Equals(hirerToRemove)) return;
        
        _hiredByWho.RemoveHiredStaff(this, dateFired);
        _hiredByWho = null;
    }

    public void AddNewHiringToHiringHistory(Hiring newHiring)
    {
        if (_hiringHistory.Contains(newHiring)) return;
        _hiringHistory.Add(newHiring);
    }
    
    public void UpdateFireDateInHiringHistory(Organizer organizerToEdit, Staff staffToEdit, DateOnly dateFired)
    {
        foreach (Hiring hiring in _hiringHistory)
        {
            if (dateFired.Equals(hiring.DateFired))
            {
                return;
            }
            if (hiring.Organizer.Equals(organizerToEdit) && hiring.Staff.Equals(staffToEdit))
            {
                hiring.DateFired = dateFired;
            }
        }
        organizerToEdit.UpdateFireDateInHiringHistory(organizerToEdit, staffToEdit, dateFired);
    }
    
    //Probably Will be needed later
    /*
    public void RemoveFromHiringHistory(Hiring hiringToRemove)
    {
        if (!(_hiringHistory.Contains(hiringToRemove))) return;

        _hiringHistory.Remove(hiringToRemove);
    }*/

}