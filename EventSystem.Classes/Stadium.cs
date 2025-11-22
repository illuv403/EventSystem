namespace EventSystem.Classes;

public class Stadium : Location
{
    public Stadium(uint capacity, string address , List<Event> eventsAssigned) 
        : base(capacity, address, eventsAssigned)
    {
        
    }
}