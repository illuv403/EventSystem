using System.Xml.Serialization;

namespace EventSystem.Classes;

public static class Persistence
{
    private static string DataDirectory = "Data";

    public static void SaveAllData(string directoryPath = null)
    {
        if (directoryPath != null) DataDirectory = directoryPath;
        if (!Directory.Exists(DataDirectory)) Directory.CreateDirectory(DataDirectory);
        
        Save("addresses.xml", Address.AddressList.ToList());
        Save("clubs.xml", Club.ClubList.ToList());
        Save("customers.xml", Customer.CustomerList.ToList());
        Save("events.xml", Event.EventList.ToList());
        Save("fanzone.xml", FanZone.FanZoneList.ToList());
        Save("female.xml", Female.List.ToList());
        Save("hiring.xml", Hiring.List.ToList());
        Save("locations.xml", Location.LocationList.ToList());
        Save("male.xml", Male.List.ToList());
        Save("musicals.xml", Musical.MusicalList.ToList());
        Save("orders.xml", Order.List.ToList());
        Save("organizers.xml", Organizer.OrganizerList.ToList());
        Save("other.xml", Other.OtherList.ToList());
        Save("scenes.xml", Scene.SceneList.ToList());
        Save("sports.xml", Sport.SportList.ToList());
        Save("stadiums.xml", Stadium.StadiumList.ToList());
        Save("staff.xml", Staff.StaffList.ToList());
        Save("standard.xml", Standard.StandardList.ToList());
        Save("standup.xml", Standup.StandupList.ToList());
        Save("vip.xml", Vip.VipList.ToList());
    }
    
    public static void LoadAllData(string directoryPath = null)
    {
        if (directoryPath != null) DataDirectory = directoryPath;
        
        Address.LoadExtent(Load<List<Address>>("addresses.xml") ?? new List<Address>());
        
        Location.LoadExtent(Load<List<Location>>("Location.xml") ?? new List<Location>());
        Club.LoadExtent(Load<List<Club>>("clubs.xml") ?? new List<Club>());
        Scene.LoadExtent(Load<List<Scene>>("scenes.xml") ?? new List<Scene>());
        Stadium.LoadExtent(Load<List<Stadium>>("stadiums.xml") ?? new List<Stadium>());

        Female.LoadExtent(Load<List<Female>>("female.xml") ?? new List<Female>());
        Male.LoadExtent(Load<List<Male>>("male.xml") ?? new List<Male>());
        Other.LoadExtent(Load<List<Other>>("other.xml") ?? new List<Other>());
        Customer.LoadExtent(Load<List<Customer>>("customers.xml") ?? new List<Customer>());
        Organizer.LoadExtent(Load<List<Organizer>>("organizers.xml") ?? new List<Organizer>());
        Staff.LoadExtent(Load<List<Staff>>("staff.xml") ?? new List<Staff>());

        Event.LoadExtent(Load<List<Event>>("events.xml") ?? new List<Event>());
        Musical.LoadExtent(Load<List<Musical>>("musicals.xml") ?? new List<Musical>());
        Sport.LoadExtent(Load<List<Sport>>("sports.xml") ?? new List<Sport>());
        Standup.LoadExtent(Load<List<Standup>>("standup.xml") ?? new List<Standup>());

        FanZone.LoadExtent(Load<List<FanZone>>("fanzone.xml") ?? new List<FanZone>());
        Standard.LoadExtent(Load<List<Standard>>("standard.xml") ?? new List<Standard>());
        Vip.LoadExtent(Load<List<Vip>>("vip.xml") ?? new List<Vip>());
        
        Order.LoadExtent(Load<List<Order>>("orders.xml") ?? new List<Order>());

        Hiring.LoadExtent(Load<List<Hiring>>("hiring.xml") ?? new List<Hiring>());
    }

    private static void Save<T>(string fileName, T data)
    {
        using var writer = new StreamWriter(fileName);
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(writer, data);
    }

    private static T? Load<T>(string fileName)
    {
        if (!File.Exists(fileName))
            return default;
        using var reader = new StreamReader(fileName);
        var serializer = new XmlSerializer(typeof(T));
        return (T?)serializer.Deserialize(reader);
    }
}