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
    [JsonIgnore]
    public Address Address { get; }
    public decimal Salary { get; set; }
    
    [JsonIgnore]
    public Staff? Manager { get; }
    
    [JsonIgnore]
    public List<Staff> Subordinates { get; }
    
    [JsonIgnore]
    public List<Event> Events { get; }
    [JsonIgnore]
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

    public Staff() : base()
    {
    }
    
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