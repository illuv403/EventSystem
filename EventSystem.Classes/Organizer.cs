namespace EventSystem.Classes;

public class Organizer : Person
{
    private static readonly List<Organizer> _organizerList = [];
    public static IReadOnlyList<Organizer> OrganizerList => _organizerList;
    
    public decimal Profit { get; }
    
    public List<Staff> Staff { get; }
    public List<Event> Events { get; }
    
    public Organizer(string name, string surname, string email, string phoneNumber, DateOnly birthDate, decimal profit,  List<Staff> staff, List<Event> events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Profit = profit;
        
        Staff = staff;
        Events = events;
        
        _organizerList.Add(this);
    }
}