namespace EventSystem.Classes;

public class Location
{
    private uint _capacity;
    private string _address;
    
    private List<Event> _eventsAssigned;

    public Location(uint capacity, string address,  List<Event> eventsAssigned)
    {
        _capacity = capacity;
        _address = address;
        _eventsAssigned = eventsAssigned;
    }
}