namespace EventSystem.Classes;

public class Event
{
    public string Title { get; }
    public DateTime StartDateAndTime{ get; }
    public DateTime EndDateAndTime{ get; }
    public string Description{ get; }

    public List<Organizer> Organizers { get; } = new();
    public List<Staff>? StaffAssigned { get; } = new();
    public List<Customer>? InWhoseWishList { get; } = new();
    public Location Location{ get; }
    
    // event ticket association list?
    public List<Ticket>? TicketsForEvent { get; } = new();
    public Event(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description, List<Organizer> organizers, List<Staff>? staffAssigned,
        List<Customer>? inWhoseWishList, Location location, List<Ticket>? ticketsForEvent)
    {
        Title = title;
        StartDateAndTime = startDateAndTime;
        EndDateAndTime = endDateAndTime;
        Description = description;
        
        Organizers = organizers;
        StaffAssigned = staffAssigned;
        InWhoseWishList = inWhoseWishList;
        Location = location;
        
        TicketsForEvent = ticketsForEvent;
    }

    
}