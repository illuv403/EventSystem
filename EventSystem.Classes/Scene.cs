namespace EventSystem.Classes;

public class Scene : Location
{
    public Scene(uint capacity, string address, List<Event>? eventsAssigned) 
        : base(capacity, address, eventsAssigned)
    {
        
    }
}