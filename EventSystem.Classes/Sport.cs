namespace EventSystem.Classes;

public class Sport : Event
{
    private static readonly List<Sport> _sportList = [];
    public static IReadOnlyList<Sport> SportList => _sportList;
    
    public Sport(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff> staffAssigned, List<Customer> inWhoseWishList, Location location, List<Ticket> ticketsForEvent) 
        : base(title, startDateAndTime, endDateAndTime, description, organizers, staffAssigned, inWhoseWishList, location, ticketsForEvent)
    {
        _sportList.Add(this);
    }

    public Sport() : base()
    {
    }
    
    public static void LoadExtent(List<Sport>? list)
    {
        _sportList.Clear();
        
        if(list != null)
            _sportList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _sportList.Clear();   
    }
}