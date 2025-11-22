namespace EventSystem.Classes;

public class Standup : Event
{
    public Standup(string title, DateTime startDateAndTime, DateTime endDateAndTime, string description,
        List<Organizer> organizers, List<Staff?> staffAssigned,List<Customer?> inWishList, Location location, List<Ticket?> ticketsForEvent) 
        : base(title, startDateAndTime, endDateAndTime, description, organizers, staffAssigned, inWishList,location,  ticketsForEvent)
    {
    }
}