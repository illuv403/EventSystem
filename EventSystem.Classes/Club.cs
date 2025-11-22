namespace EventSystem.Classes;

public class Club : Location
{
    public Club(uint capacity, string address, List<Event> eventsAssigned) 
        : base(capacity, address , eventsAssigned)
    {
        
    }
}