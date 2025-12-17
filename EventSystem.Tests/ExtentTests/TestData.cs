using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class TestData
{
    // Caching used to prevent duplicate objects from being added to extents during tests
    private static Address? _cachedAddress;
    private static Location? _cachedLocation;
    private static Customer? _cachedCustomer;
    private static Organizer? _cachedOrganizer;
    private static Event? _cachedEvent;
    private static Order? _cachedOrder;
    private static Staff? _cachedStaff;

    public static void ClearCache()
    {
        _cachedAddress = null;
        _cachedLocation = null;
        _cachedCustomer = null;
        _cachedOrganizer = null;
        _cachedEvent = null;
        _cachedOrder = null;
        _cachedStaff = null;
    }

    // <<Additional>> //
    private static DateOnly BirthDate() => new(2005, 01, 01);
    private static DateTime StartDateTime() => new(2026, 02, 01, 19, 00, 00);
    private static DateTime EndDateTime() => new(2026, 02, 02, 23, 30, 00);
    private static DateOnly HiredDate() => new(1999, 05, 20);
    private static DateOnly FiredDate() => new(2026, 03, 01);

    private static string Description() => "This is a simple description.";
    private static string _Address() => "Traktorzystów 12";
    private static string PhoneNumber() => "+48019486912";

    private static Staff.StaffRole StaffRole() => Classes.Staff.StaffRole.Security;

    // <<Objects>> //
    public static Address Address()
    {
        if (_cachedAddress == null)
            _cachedAddress = new("Poland", "Warsaw", _Address(), "12", "02-495", new List<Staff>());
        return _cachedAddress;
    }

    public static Location Location()
    {
        if (_cachedLocation == null)
            _cachedLocation = new(455, _Address(), new List<Event>());
        return _cachedLocation;
    }

    public static Customer Customer()
    {
        if (_cachedCustomer == null)
            _cachedCustomer = new("Daniel", "Eroth", "d.eroth@gmail.com", PhoneNumber(), BirthDate(), new List<Order>());
        return _cachedCustomer;
    }

    public static Organizer Organizer()
    {
        if (_cachedOrganizer == null)
            _cachedOrganizer = new("Alexandra", "Kowalska", "kow.all@gmail.com", PhoneNumber(), BirthDate(),
                new decimal(2290.0), new List<Staff>(), new List<Event>());
        return _cachedOrganizer;
    }

    public static Event Event()
    {
        if (_cachedEvent == null)
            _cachedEvent = new("TTL", StartDateTime(), EndDateTime(), Description(),
                new List<Organizer>{Organizer()}, new List<Staff>(), 
                new List<Customer>(), Location(), new List<Ticket>());
        return _cachedEvent;
    }

    public static Order Order()
    {
        if (_cachedOrder == null)
            _cachedOrder =
                new("ID01", Customer(), new List<Ticket>());
        return _cachedOrder;
    }
    
    public static Staff Staff()
    {
        if (_cachedStaff == null)
            _cachedStaff = new("Ivan", "Zareba", "zareba@gmail.com", PhoneNumber(), BirthDate(), StaffRole(), Address(), new decimal(2568.50), new List<Event>(), Organizer(), HiredDate(), null, new List<Staff>());
        return _cachedStaff;
    }

    public static Club Club() => new(123, _Address(), new List<Event>());

    public static FanZone FanZone() => new("G4", new decimal(163.35), Event(), Order());

    public static Female Female() => new("Joanna", "Martendez", "j.mart@gmail.com", PhoneNumber(), BirthDate());

    public static Hiring Hiring() => new(Staff(), Organizer(), HiredDate(), FiredDate());
    
    public static Male Male() => new("Marcin", "Kowalski", "kow.mar@gmail.com", PhoneNumber(), BirthDate());

    public static Musical Musical() => new("Christmas Musical", StartDateTime(), EndDateTime(), Description(), 
        new List<Organizer>{Organizer()}, new List<Staff>(), new List<Customer>(), 
        Location(), new List<Ticket>());

    public static Other Other() => new("Mutor", "Figdi", "figdi@gmail.com", PhoneNumber(), BirthDate(), "YWO");

    public static Scene Scene() => new(455, _Address(), new List<Event>());

    public static Sport Sport() => new("Sport Event #1", StartDateTime(), EndDateTime(), Description(), 
        new List<Organizer>{Organizer()}, new List<Staff>(), new List<Customer>(), 
        Location(), new List<Ticket>());

    public static Stadium Stadium() => new(933, _Address(), new List<Event>());
    
    public static Standard Standard() => new("G16", new decimal(49.99), "L-4", Event(), Order());
    
    public static Standup Standup() => new("Standup #1", StartDateTime(), EndDateTime(), Description(),
        new List<Organizer>{Organizer()},new List<Staff>(), new List<Customer>(), 
        Location(), new List<Ticket>());

    public static Vip Vip() => new("M15", new decimal(89.99), "V-8", Event(), Order());
}
