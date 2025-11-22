namespace EventSystem.Classes;

public class Event
{
    private string _title;
    private DateTime _startDateAndTime;
    private DateTime _endDateAndTime;
    private string _description;
    
    private List<Organizer> _organizers;
    private List<Staff?> _staffAssigned;
    private List<Customer?> _inWishList;
    private Location _location;
    
    // event ticket association list?
    private List<Ticket?> _ticketsForEvent;
    public Event(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description, List<Organizer> organizers, List<Staff?> staffAssigned,
        List<Customer?> inWishList, Location location, List<Ticket?> ticketsForEvent)
    {
        _title = title;
        _startDateAndTime = startDateAndTime;
        _endDateAndTime = endDateAndTime;
        _description = description;
        
        _organizers = organizers;
        _staffAssigned = staffAssigned;
        _inWishList = inWishList;
        _location = location;
        
        _ticketsForEvent = ticketsForEvent;
    }

    
}