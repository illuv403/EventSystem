using EventSystem.Classes;

namespace EventSystem.App;

class Program
{
    static void Main(string[] args)
    {
        var ev = new Event("New Event",
            new DateTime(2025, 12, 12), new DateTime(2025, 12, 23), "New event",
            new List<Organizer>(), new List<Staff>(), new List<Customer>(),
            new Location(10000, "Al. Wilanowska 12", new List<Event>()), new List<Ticket>());
        var st = new Staff("Henry", "Grey",
            "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
            Staff.StaffRole.Bartender, new Address("Poland", "Warsaw",
                "Al. Wilanowska 12", "125", "02-123", new List<Staff>()), 599.99m, new List<Event>(),
            new Organizer("Anne", "Grey",
                "test@gmail.com", "+48573370352",
                new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()),
            null, new List<Staff>());

        st.AddAssignedEvent(ev);
        st.GetAssignedEvents();
        st.RemoveAssignedEvent(ev);
    }
}