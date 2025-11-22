namespace EventSystem.Classes;

public class Staff : Person
{
    private string _role;
    private Address _address;
    private decimal _salary;

    private List<Event?> _events;

    private Organizer _organizer;
    private Staff _manager;

    public Staff(string name, string surname, string email, string phoneNumber, DateTime birthDate, string role,
        Address address, decimal salary, List<Event?> events, Organizer organizer, Staff manager)
        : base(name, surname, email, phoneNumber, birthDate)
    {
        _role = role;
        _address = address;
        _salary = salary;

        _events = events;
        _organizer = organizer;
        _manager = manager;
    }
}