namespace EventSystem.Classes;

public class Location
{
    public uint Capacity { get; }
    public string Address { get; }

    public List<Event>? EventsAssigned { get; } = new();

    public Location(uint capacity, string address,  List<Event>? eventsAssigned)
    {
        Capacity = capacity;
        Address = address;
        EventsAssigned = eventsAssigned;
    }
}