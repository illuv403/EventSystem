namespace EventSystem.Classes;

public class Organizer : Person
{
    public decimal Profit { get; }
    public List<Staff>? Staff { get; } = new();

    public List<Event>? Events { get; } = new();
    
    public Organizer(string name, string surname, string email, string phoneNumber, DateTime birthDate, decimal profit,  List<Staff>? staff, List<Event>? events) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Profit = profit;
        Staff = staff;
        
        Events = events;
    }
    
}