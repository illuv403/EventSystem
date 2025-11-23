namespace EventSystem.Classes;

public class Musical : Event
{
    public Musical(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff>? staffAssigned, List<Customer>? inWhoseWishList, Location location, List<Ticket>? ticketsForEvent)
        : base(title, startDateAndTime, endDateAndTime, description, organizers, staffAssigned, inWhoseWishList, location, ticketsForEvent)
    {
    }
}