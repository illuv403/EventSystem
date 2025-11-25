using EventSystem.Classes;

namespace EventSystem.Tests;

public class PersistenceTests
{
    private readonly string testDir = "TestPersistence";

    public PersistenceTests()
    {
        if (!Directory.Exists(testDir))
            Directory.CreateDirectory(testDir);
        
        ClearAllExtents();
    }

    private void ClearAllExtents()
    {
        // Reseting all extents
        Address.ClearExtent();
        Club.ClearExtent();
        Customer.ClearExtent();
        Event.ClearExtent();
        FanZone.ClearExtent();
        Female.ClearExtent();
        Hiring.ClearExtent();
        Location.ClearExtent();
        Male.ClearExtent();
        Musical.ClearExtent();
        Order.ClearExtent();
        Organizer.ClearExtent();
        Other.ClearExtent();
        Scene.ClearExtent();
        Sport.ClearExtent();
        Stadium.ClearExtent();
        Staff.ClearExtent();
        Standard.ClearExtent();
        Standup.ClearExtent();
        Vip.ClearExtent();
    }

    // [Fact]
    // public void saveAllTest()
    // {
    //     var a = new Address("Poland", "Warsaw", "Ryżowa", "10", "02-495", new List<Staff>());
    //     var c = new Club(123, "str", new List<Event>());
    //     // var cs = new Customer("Name", "Surname", "smth@gmail.com", "+48010344534",
    //     //     new DateOnly(2005, 01, 01), new List<Order>());
    //     var e = new Event("TTL", new DateTime(2025, 12, 25), new DateTime(2025, 12, 26),
    //         "Some description right here", new List<Organizer>(), new List<Staff>(), new List<Customer>(),
    //         new Location(), new List<Ticket>());
    //     var fz = new FanZone("G4", new decimal(163.35), new Event(), new Order());
    //     var f = new Female("Joanna", "Martendes", "j.mart@gmail.com", "+48019486912", new DateOnly(2000, 05, 29));
    //     var h = new Hiring(
    //         new Staff("Ivan", "Zareba", "zareba@gmail.com", "+48019486912", new DateOnly(1976, 02, 29), Staff.StaffRole.Cameramen, new Address(), new decimal(2568.50), new List<Event>(), new Organizer("Joanna", "Martendes", "j.mart@gmail.com", "+48019486912", new DateOnly(2000, 05, 29), new decimal(1999.99), new List<Staff>(), new List<Event>()), 
    //             null, 
    //             new List<Staff>()), new Organizer("Alexandra", "Kowalska", "kow.all@gmail.com", "+48991776543", new DateOnly(1999, 01, 12), new decimal(2290.0), new List<Staff>(), new List<Event>()), new DateOnly(2025, 11, 23), null);
    //     var l = new Location(1566, "New Street 43/12", new List<Event>());
    //     var m = new Male("Ivan", "Zareba", "zareba@gmail.com", "+48019486912", new DateOnly(1976, 02, 29));
    //     var mu = new Musical("NewMusical", new DateTime(2025, 12, 25), new DateTime(2025, 12,26), "Some description of the event", 
    //         new List<Organizer>(), new List<Staff>(), new List<Customer>(), new Location(1000, "Address #1", new List<Event>()), new List<Ticket>());
    //     var o = new Order(new Customer("Tyruan", "Restok", 
    //         "tt.restok@gmail.com", "+48976546444", new DateOnly(2000, 11, 12), new List<Order>()), new List<Ticket>());
    //     var or = new Organizer("Alexandra", "Kowalska", "kow.all@gmail.com",
    //         "+48991776543",
    //         new DateOnly(1999, 01, 12), new decimal(2290.0), new List<Staff>(),
    //         new List<Event>());
    //     var ot = new Other("Mutor", "Figdi", "figdi@gmail.com", "+48019486912", new DateOnly(2007, 01, 29), "YY");
    //     var sc = new Scene(455, "New Street 12/12", new List<Event>());
    //     var sp = new Sport("Sport Event #1", new DateTime(2026, 11, 11, 21, 00, 00), new DateTime(2026, 11, 11, 23, 30, 00), "Some description about event #1", new List<Organizer>(),
    //         new List<Staff>(), new List<Customer>(), new Location(), new List<Ticket>());
    //     var st = new Stadium(956, "New Street 12/12", new List<Event>());
    //     var s = new Staff("Ivan", "Zareba", "zareba@gmail.com", "+48019486912", new DateOnly(1976, 02, 29), Staff.StaffRole.Stagehand, new Address(), new decimal(2578.0), new List<Event>(), 
    //         new Organizer("Alexandra", "Kowalska", "kow.all@gmail.com", "+48991776543", new DateOnly(1999, 01, 12), new decimal(2290.0), new List<Staff>(), new List<Event>()), null, new List<Staff>());
    //     var stan = new Standard("G16", new decimal(49.99), "L-4", 
    //         new Event("TTL", new DateTime(2026, 11, 25), new DateTime(2026, 11, 26),
    //             "Some description right here", new List<Organizer>(), new List<Staff>(), new List<Customer>(),
    //             new Location(), new List<Ticket>()), new Order());
    //     var stup = new Standup("Standup #1", new DateTime(2028, 11, 11, 21, 00, 00), new DateTime(2028, 11, 11, 23, 30, 00), "Some description about event #1", new List<Organizer>(),
    //         new List<Staff>(), new List<Customer>(), new Location(), new List<Ticket>());
    //     var vip = new Vip("G16", new decimal(49.99), "L-4", 
    //         new Event("TTL", new DateTime(2027, 11, 25), new DateTime(2027, 11, 26),
    //             "Some description right here", new List<Organizer>(), new List<Staff>(), new List<Customer>(),
    //             new Location(), new List<Ticket>()), new Order());
    //
    //     Persistence.SaveAllData(testDir);
    //     
    //     ClearAllExtents();
    //     
    //     Assert.Empty(Address.AddressList);
    //     Assert.Empty(Club.ClubList);
    //     // Assert.Empty(Customer.CustomerList);
    //     Assert.Empty(Event.EventList);
    //     Assert.Empty(FanZone.FanZoneList);
    //     Assert.Empty(Female.List);
    //     Assert.Empty(Hiring.List);
    //     Assert.Empty(Location.LocationList);
    //     Assert.Empty(Male.List);
    //     Assert.Empty(Musical.MusicalList);
    //     Assert.Empty(Order.List);
    //     Assert.Empty(Organizer.OrganizerList);
    //     Assert.Empty(Other.OtherList);
    //     Assert.Empty(Scene.SceneList);
    //     Assert.Empty(Sport.SportList);
    //     Assert.Empty(Stadium.StadiumList);
    //     Assert.Empty(Staff.StaffList);
    //     Assert.Empty(Standard.StandardList);
    //     Assert.Empty(Standup.StandupList);
    //     Assert.Empty(Vip.VipList);
    //     
    //     Persistence.LoadAllData();
    //     
    //     Assert.Single(Address.AddressList);
    //     Assert.Equal("Poland", Address.AddressList[0].Country);
    //     
    //     Assert.Single(Club.ClubList);
    //     Assert.Equal(123, Club.ClubList[0].Capacity);
    //     
    //     // Assert.Single(Customer.CustomerList);
    //     // Assert.Equal("Name", Customer.CustomerList[0].Name);
    //     
    //     Assert.Single(Event.EventList);
    //     Assert.Equal("TTL", Event.EventList[0].Title);
    //     
    //     Assert.Single(FanZone.FanZoneList);
    //     Assert.Equal("G4", FanZone.FanZoneList[0].GateNumber);
    //     
    //     Assert.Single(Female.List);
    //     Assert.Equal("Joanna", Female.List[0].Name);
    //     
    //     Assert.Single(Hiring.List);
    //     Assert.Equal(new DateOnly(2025, 11, 23), Hiring.List[0].DateHired);
    //     
    //     Assert.Single(Location.LocationList);
    //     Assert.Equal("New Street 43/12", Location.LocationList[0].Address);
    //     
    //     Assert.Single(Male.List);
    //     Assert.Equal("Ivan", Male.List[0].Name);
    //     
    //     Assert.Single(Musical.MusicalList);
    //     Assert.Equal("NewMusical", Musical.MusicalList[0].Title);
    //     
    //     Assert.Single(Order.List);
    //     Assert.Equal("tt.restok@gmail.com", Order.List[0].CreatedByCustomer.Email);
    //     
    //     Assert.Single(Organizer.OrganizerList);
    //     Assert.Equal("Alexandra", Organizer.OrganizerList[0].Name);
    //     
    //     Assert.Single(Other.OtherList);
    //     Assert.Equal("YY", Other.OtherList[0].Type);  
    //     
    //     Assert.Single(Scene.SceneList);
    //     Assert.Equal("New Street 12/12", Scene.SceneList[0].Address);
    //     
    //     Assert.Single(Sport.SportList);
    //     Assert.Equal("Sport Event #1", Sport.SportList[0].Title);
    //     
    //     Assert.Single(Stadium.StadiumList);
    //     Assert.Equal(956, Stadium.StadiumList[0].Capacity);
    //     
    //     Assert.Single(Staff.StaffList);
    //     Assert.Equal("zareba@gmail.com", Staff.StaffList[0].Email);
    //     
    //     Assert.Single(Standard.StandardList);
    //     Assert.Equal("L-4", Standard.StandardList[0].SeatNumber);
    //     
    //     Assert.Single(Standup.StandupList);
    //     Assert.Equal("Standup #1", Standup.StandupList[0].Title);
    //     
    //     Assert.Single(Vip.VipList);
    //     Assert.Equal("G16", Vip.VipList[0].GateNumber);
    // }
}