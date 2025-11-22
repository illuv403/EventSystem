namespace EventSystem.Classes;

public class Address
{
    private string _country;
    private string _city;
    private string _street;
    private string _appNumber;
    private string _index;
    
    private List<Staff?>  _staff;
    private List<Event?> _eventsHere;
    
    public Address(string country, string city, string street, string appNumber, List<Staff?> staff,  List<Event?> eventsHere)
    {
        _country = country;
        _city = city;
        _street = street;
        _appNumber = appNumber;
        _index = street;
        
        _staff = staff;
        _eventsHere = eventsHere;
    }
}