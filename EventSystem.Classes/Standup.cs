namespace EventSystem.Classes;

public class Standup : Event
{
    private static readonly List<Standup> _standupList = [];
    public static IReadOnlyList<Standup> StandupList => _standupList;
    
    public Standup(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff> staffAssigned,List<Customer> inWhoseWishList, Location location, List<Ticket> ticketsForEvent) 
        : base(title, startDateAndTime, endDateAndTime, description, organizers, staffAssigned, inWhoseWishList,location,  ticketsForEvent)
    {
        _standupList.Add(this);
    }
    
    public static void LoadExtent(List<Standup>? list)
    {
        _standupList.Clear();
        
        if(list != null)
            _standupList.AddRange(list);
    }
}