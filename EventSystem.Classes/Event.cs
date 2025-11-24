namespace EventSystem.Classes;

public class Event
{
    private static readonly List<Event> _eventList = [];
    public static IReadOnlyList<Event> EventList => _eventList;
    
    public string Title { get; }
    public DateTime StartDateAndTime{ get; }
    public DateTime EndDateAndTime{ get; }
    public string Description{ get; }

    public List<Organizer> Organizers { get; }
    public List<Staff> StaffAssigned { get; }
    public List<Customer> InWhoseWishList { get; }
    public Location Location{ get; }
    
    // event ticket association list?
    public List<Ticket> TicketsForEvent { get; }
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

    public static void LoadExtent(List<Event>? list)
    {
        _eventList.Clear();
        
        if(list != null)
            _eventList.AddRange(list);
    }
}