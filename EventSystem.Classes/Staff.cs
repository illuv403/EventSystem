using System.Text.Json.Serialization;
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
    public StaffRole Role { get; set; }
    [JsonInclude]
    public Address Address { get; private set; }
    public decimal Salary { get; set; }
    
    [JsonInclude]
    public Staff? Manager { get; private set; }
    
    [JsonInclude]
    public List<Staff> Subordinates { get; private set; }
    
    [JsonInclude]
    public List<Event> Events { get; private set; }
    
    [JsonInclude]
    public Organizer Organizer { get; private set; }

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

    public Staff() { }
    
    public static void LoadExtent(List<Staff>? list)
    {
        _staffList.Clear();
        
        if(list != null)
            _staffList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _staffList.Clear();   
    }
}