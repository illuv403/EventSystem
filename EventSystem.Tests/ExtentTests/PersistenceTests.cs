using EventSystem.Classes;
using EventSystem.Tests.ExtentTests;

namespace EventSystem.Tests;

public class PersistenceTests : IDisposable
{
    private readonly string testDir = "TestPersistence";

    public PersistenceTests()
    {
        if (!Directory.Exists(testDir))
            Directory.CreateDirectory(testDir);
        
        ClearAllExtents();
        TestData.ClearCache();
    }
    
    public void Dispose()
    {
        ClearAllExtents();
        TestData.ClearCache();
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

    [Fact]
    public void saveAllTest()
    {
        var a = TestData.Address();
        var c = TestData.Club();
        var cs = TestData.Customer();
        var e = TestData.Event();
        var fz = TestData.FanZone();
        var f = TestData.Female();
        var h = TestData.Hiring();
        var l = TestData.Location();
        var m = TestData.Male();
        var mu = TestData.Musical();
        var o = TestData.Order();
        var or = TestData.Organizer();
        var ot = TestData.Other();
        var sc = TestData.Scene();
        var sp = TestData.Sport();
        var st = TestData.Stadium();
        var s = TestData.Staff();
        var stan = TestData.Standard();
        var stup = TestData.Standup();
        var vip = TestData.Vip();
    
        Persistence.SaveAllData(testDir);
        
        ClearAllExtents();
        
        Assert.Empty(Address.AddressList);
        Assert.Empty(Club.ClubList);
        Assert.Empty(Customer.CustomerList);
        Assert.Empty(Event.EventList);
        Assert.Empty(FanZone.FanZoneList);
        Assert.Empty(Female.List);
        Assert.Empty(Hiring.List);
        Assert.Empty(Location.LocationList);
        Assert.Empty(Male.List);
        Assert.Empty(Musical.MusicalList);
        Assert.Empty(Order.List);
        Assert.Empty(Organizer.OrganizerList);
        Assert.Empty(Other.OtherList);
        Assert.Empty(Scene.SceneList);
        Assert.Empty(Sport.SportList);
        Assert.Empty(Stadium.StadiumList);
        Assert.Empty(Staff.StaffList);
        Assert.Empty(Standard.StandardList);
        Assert.Empty(Standup.StandupList);
        Assert.Empty(Vip.VipList);
        
        Persistence.LoadAllData(testDir);
        
        Assert.Single(Address.AddressList);
        Assert.Equal("Poland", Address.AddressList[0].Country);
        
        Assert.Single(Club.ClubList);
        Assert.Equal(123, Club.ClubList[0].Capacity);
        
        Assert.Single(Customer.CustomerList);
        Assert.Equal("Daniel", Customer.CustomerList[0].Name);
        
        Assert.Single(Event.EventList);
        Assert.Equal("TTL", Event.EventList[0].Title);
        
        Assert.Single(FanZone.FanZoneList);
        Assert.Equal("G4", FanZone.FanZoneList[0].GateNumber);
        
        Assert.Single(Female.List);
        Assert.Equal("Joanna", Female.List[0].Name);
        
        Assert.Equal(2, Hiring.List.Count);
        Assert.Equal(new DateOnly(0001, 01, 01), Hiring.List[0].DateHired);
        
        Assert.Single(Location.LocationList);
        Assert.Equal("Traktorzystów 12", Location.LocationList[0].Address);
        
        Assert.Single(Male.List);
        Assert.Equal("Marcin", Male.List[0].Name);
        
        Assert.Single(Musical.MusicalList);
        Assert.Equal("Christmas Musical", Musical.MusicalList[0].Title);
        
        Assert.Single(Order.List);
        Assert.Equal("d.eroth@gmail.com", Order.List[0].CreatedByCustomer.Email);
        
        Assert.Single(Organizer.OrganizerList);
        Assert.Equal("Alexandra", Organizer.OrganizerList[0].Name);
        
        Assert.Single(Other.OtherList);
        Assert.Equal("YWO", Other.OtherList[0].Type);  
        
        Assert.Single(Scene.SceneList);
        Assert.Equal("Traktorzystów 12", Scene.SceneList[0].Address);
        
        Assert.Single(Sport.SportList);
        Assert.Equal("Sport Event #1", Sport.SportList[0].Title);
        
        Assert.Single(Stadium.StadiumList);
        Assert.Equal(933, Stadium.StadiumList[0].Capacity);
        
        Assert.Single(Staff.StaffList);
        Assert.Equal("zareba@gmail.com", Staff.StaffList[0].Email);
        
        Assert.Single(Standard.StandardList);
        Assert.Equal("L-4", Standard.StandardList[0].SeatNumber);
        
        Assert.Single(Standup.StandupList);
        Assert.Equal("Standup #1", Standup.StandupList[0].Title);
        
        Assert.Single(Vip.VipList);
        Assert.Equal("M15", Vip.VipList[0].GateNumber);
    }

}