namespace EventSystem.Classes;

public class Musical : Event
{
    private static readonly List<Musical> _musicalList = [];
    public static IReadOnlyList<Musical> MusicalList => _musicalList;
    
    public Musical(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff> staffAssigned, List<Customer> inWhoseWishList, Location location, List<Ticket> ticketsForEvent)
        : base(title, startDateAndTime, endDateAndTime, description, organizers, staffAssigned, inWhoseWishList, location, ticketsForEvent)
    {
        _musicalList.Add(this);
    }
    
    public static void LoadExtent(List<Musical>? list)
    {
        _musicalList.Clear();
        if(list != null)
            _musicalList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _musicalList.Clear();   
    }
}