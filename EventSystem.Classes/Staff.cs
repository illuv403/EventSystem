namespace EventSystem.Classes;

public class Staff : Person
{
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

    public List<Event>? Events { get; } = new();

    public Organizer Organizer { get; }
    public Staff? Manager { get; }
    
    public List<Staff>? Subordinates { get; } = new();

    public Staff(string name, string surname, string email, string phoneNumber, DateTime birthDate, int role,
        Address address, decimal salary, List<Event>? events, Organizer organizer, Staff manager, List<Staff>? subordinates)
        : base(name, surname, email, phoneNumber, birthDate)
    {
        Role = (StaffRole)role;
        Address = address;
        Salary = salary;

        Events = events;
        Organizer = organizer;
        Manager = manager;
        Subordinates = subordinates;
    }
}