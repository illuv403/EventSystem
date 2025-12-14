using EventSystem.Classes;

namespace EventSystem.App;

class Program
{
    static void Main(string[] args)
    {
        Address oldAddr = new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>());
        
        Organizer organizer = new Organizer("Anne", "Grey",
            "test@gmail.com", "+48573370352",
            new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>());
        
        Staff staff = new Staff("Henry", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender , oldAddr, 599.99m, new List<Event>(),
            organizer,
            null, new List<Staff>());
        
        
        
        organizer.AddHiredStaff(staff, new DateOnly(2001, 1, 1), null);
        organizer.RemoveHiredStaff(staff, new DateOnly(2001, 1, 2));
    }
}