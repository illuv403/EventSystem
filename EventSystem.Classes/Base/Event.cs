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
    private HashSet<Organizer> _eventOrganizers = new();
    private HashSet<Ticket> _ticketsForEvent = new();
    private Location _location;

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

        // insures that event will have at least 1 organizer
        if (organizers.Count == 0)
        {
            throw new ArgumentException("Event must have at least one organizer.");
        }

        foreach (var organizer in organizers)
        {
            AddEventOrganizer(organizer);
        }
        Organizers = organizers;

        foreach (var staff in staffAssigned)
        {
            AddStaffAssigned(staff);
        }
        StaffAssigned = staffAssigned;

        foreach (var customer in inWhoseWishList)
        {
            AddInWishList(customer);
        }

        foreach (var ticket in ticketsForEvent)
        {
            AddTicket(ticket);
        }
        
        InWhoseWishList = inWhoseWishList;
        Location = location;
        _location = location;
        _location.AddEvent(this);
        
        TicketsForEvent = ticketsForEvent;

        _eventList.Add(this);
    }

    public Event()
    {
    }

    public static void LoadExtent(List<Event>? list)
    {
        _eventList.Clear();

        if (list != null)
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
        if (_inWhoseWishList.Contains(customerToAdd)) return;

        _inWhoseWishList.Add(customerToAdd);
        customerToAdd.AddWishForEvent(this);
    }

    public void RemoveInWishList(Customer customerToRemove)
    {
        if (!_inWhoseWishList.Contains(customerToRemove)) return;

        _inWhoseWishList.Remove(customerToRemove);
        customerToRemove.RemoveWishForEvent(this);
    }

    public void UpdateInWishList(Customer customerToRemove, Customer customerToAdd)
    {
        RemoveInWishList(customerToRemove);
        AddInWishList(customerToAdd);
    }


    public HashSet<Organizer> GetEventOrganizers()
    {
        return [.._eventOrganizers];
    }

    public void AddEventOrganizer(Organizer organizerToAdd)
    {
        if (_eventOrganizers.Contains(organizerToAdd)) return;

        _eventOrganizers.Add(organizerToAdd);
        organizerToAdd.AddAssignedEvent(this);
    }

    public void RemoveEventOrganizer(Organizer organizerToRemove)
    {
        if (!_eventOrganizers.Contains(organizerToRemove)) return;

        _eventOrganizers.Remove(organizerToRemove);
        organizerToRemove.RemoveAssignedEvent(this);
    }

    public void UpdateEventOrganizers(Organizer organizerToRemove, Organizer organizerToAdd)
    {
        RemoveEventOrganizer(organizerToRemove);
        AddEventOrganizer(organizerToAdd);
    }

    public HashSet<Ticket> GetTicketsForEvent()
    {
        return [.._ticketsForEvent];
    }

    public void AddTicket(Ticket ticketToAdd)
    {
        if (_ticketsForEvent.Contains(ticketToAdd)) return;
        
        _ticketsForEvent.Add(ticketToAdd);
    }

    public void RemoveTicket(Ticket ticketToRemove)
    {
        if (!_ticketsForEvent.Contains(ticketToRemove)) return;
        
        _ticketsForEvent.Remove(ticketToRemove);
    }    
    
    public void UpdateTicket(Ticket ticketToUpdate)
    {
        if (ticketToUpdate.GetEventForTicket() == this)
            return;

        var oldEvent = ticketToUpdate.GetEventForTicket();
        
        oldEvent.RemoveTicket(ticketToUpdate);
        AddTicket(ticketToUpdate);
    }
    
    public Location GetLocation()
    {
        return _location;
    }
    
    public void UpdateLocation(Location locationToUpdate)
    {
        locationToUpdate.UpdateEvent(this);
    }
}