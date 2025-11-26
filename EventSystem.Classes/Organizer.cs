using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Organizer : Person
{
    private static readonly List<Organizer> _organizerList = [];
    public static IReadOnlyList<Organizer> OrganizerList => _organizerList;
    
    public decimal Profit { get; set; }
    
    [XmlIgnore]
    public List<Staff> Staff { get; }
    
    [XmlIgnore]
    public List<Event> Events { get; }
    
    public Organizer(string name, string surname, string email, string phoneNumber, DateOnly birthDate, decimal profit,  List<Staff> staff, List<Event> events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Profit = profit;
        
        Staff = staff;
        Events = events;
        
        _organizerList.Add(this);
    }

    public Organizer() : base()
    {
    }
    
    public static void LoadExtent(List<Organizer>? list)
    {
        _organizerList.Clear();
        if(list != null) _organizerList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _organizerList.Clear();   
    }
}