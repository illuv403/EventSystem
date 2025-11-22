namespace EventSystem.Classes;

public class Address
{
    public string Country { get; }
    public string City { get; }
    public string Street { get; }
    public string AppNumber { get; }
    public string Index { get; }

    private List<Staff>? Staff { get; } = new();
    private List<Event>? EventsHere { get; } = new();
    
    public Address(string country, string city, string street, string appNumber, string index, List<Staff>? staff,  List<Event>? eventsHere)
    {
        Country = country;
        City = city;
        Street = street;
        AppNumber = appNumber;
        Index = index;
        
        Staff = staff;
        EventsHere = eventsHere;
    }
}