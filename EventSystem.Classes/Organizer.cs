namespace EventSystem.Classes;

public class Organizer : Person
{
    private decimal _profit;
    private List<Staff> _staff;
    
    private List<Event?> _events;
    
    public Organizer(string name, string surname, string email, string phoneNumber, DateTime birthDate, decimal profit,  List<Staff> staff, List<Event?> events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        _profit = profit;
        _staff = staff;
        
        _events = events;
    }
    
}