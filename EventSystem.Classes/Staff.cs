using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Staff : Person
{
    private static readonly List<Staff> _staffList = [];
    public static IReadOnlyList<Staff> StaffList => _staffList;
    
    public enum StaffRole 
    {
        Security,
        Cleaner,
        Bartender,
        Stagehand,
        Cameramen,
        Manager
    }
    public StaffRole Role { get; }
    public Address Address { get; }
    public decimal Salary { get; }
    
    [XmlIgnore]
    public Staff? Manager { get; }
    
    [XmlIgnore]
    public List<Staff> Subordinates { get; }
    
    [XmlIgnore]
    public List<Event> Events { get; }
    public Organizer Organizer { get; }

    public Staff(string name, string surname, string email, string phoneNumber, DateOnly birthDate, StaffRole role,
        Address address, decimal salary, List<Event> events, Organizer organizer, Staff? manager, List<Staff> subordinates)
        : base(name, surname, email, phoneNumber, birthDate)
    {
        if (salary < 0)
            throw new ArgumentException("Salary cannot be negative");
        
        Role = role;
        Address = address;
        Salary = salary;

        Events = events;
        Organizer = organizer;
        Manager = manager;
        Subordinates = subordinates;
        
        _staffList.Add(this);
    }
    
    public static void LoadExtent(List<Staff>? list)
    {
        _staffList.Clear();
        
        if(list != null)
            _staffList.AddRange(list);
    }
}