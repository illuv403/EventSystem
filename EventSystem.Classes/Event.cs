using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public class Event
{
    private static readonly List<Event> _eventList = [];
    public static IReadOnlyList<Event> EventList => _eventList;

    public string Title { get; set; }
    public DateTime StartDateAndTime { get; set; }
    public DateTime EndDateAndTime { get; set; }
    public string Description { get; set; }

    [JsonInclude] public List<Organizer> Organizers { get; private set; }
    [JsonInclude] public List<Staff> StaffAssigned { get; private set; }
    [JsonInclude] public List<Customer> InWhoseWishList { get; private set; }
    [JsonInclude] public Location Location { get; private set; }
    [JsonInclude] public List<Ticket> TicketsForEvent { get; private set; }

    private HashSet<Staff> _staffAssigned = new();
    private HashSet<Customer> _inWhoseWishList = new();

    public Event(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff> staffAssigned,
        List<Customer> inWhoseWishList, Location location, List<Ticket> ticketsForEvent)
    {
        title = title.Trim();
        description = description.Trim();

        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.");
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description cannot be empty.");

        if (endDateAndTime <= startDateAndTime)
            throw new ArgumentException("End date cannot be before start date.");

        if (startDateAndTime <= DateTime.Now)
            throw new ArgumentException("Start date cannot be before current date.");

        Title = title;
        StartDateAndTime = startDateAndTime;
        EndDateAndTime = endDateAndTime;
        Description = description;

        Organizers = organizers;
        StaffAssigned = staffAssigned;
        InWhoseWishList = inWhoseWishList;
        Location = location;

        TicketsForEvent = ticketsForEvent;

        _eventList.Add(this);
    }

    public Event() { } 

    public static void LoadExtent(List<Event>? list)
    {
        _eventList.Clear();
        
        if(list != null)
            _eventList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _eventList.Clear();   
    }

    public HashSet<Staff> GetStaffAssigned()
    {
        return [.._staffAssigned];
    }

    public void AddStaffAssigned(Staff staffToAssign)
    {
        if (_staffAssigned.Contains(staffToAssign)) return;
        
        
        _staffAssigned.Add(staffToAssign);
        staffToAssign.AddAssignedEvent(this);
    }

    public void RemoveStaffAssigned(Staff staffToRemove)
    {
        if (!_staffAssigned.Contains(staffToRemove)) return;
        
        _staffAssigned.Remove(staffToRemove);
        staffToRemove.RemoveAssignedEvent(this);
    }

    public void UpdateStaffAssigned(Staff staffToRemove, Staff staffToAssign)
    {
        RemoveStaffAssigned(staffToRemove);
        AddStaffAssigned(staffToAssign);
    }

    public HashSet<Customer> GetInWhoseWishList()
    {
        return [.._inWhoseWishList];
    }

    public void AddInWishList(Customer customerToAdd)
    {
        if (_inWhoseWishList.Contains(customerToAdd))  return;
        
        _inWhoseWishList.Add(customerToAdd);
        customerToAdd.AddWishForEvent(this);
    }

    public void RemoveInWishList(Customer customerToRemove)
    {
        if (!_inWhoseWishList.Contains(customerToRemove))  return;
        
        _inWhoseWishList.Remove(customerToRemove);
        customerToRemove.RemoveWishForEvent(this);
    }

    public void UpdateInWishList(Customer customerToRemove, Customer customerToAdd)
    {
        RemoveInWishList(customerToRemove);
        AddInWishList(customerToAdd);
    }
}