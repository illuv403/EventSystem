using System.Xml.Serialization;

namespace EventSystem.Classes;

public static class Persistence
{
    public static void SaveAllData(string directoryPath)
    {
        Save(Path.Combine(directoryPath,"Address.xml"), Address.AddressList.ToList());
        Save(Path.Combine(directoryPath,"Club.xml"), Club.ClubList.ToList());
        Save(Path.Combine(directoryPath,"Customer.xml"), Customer.CustomerList.ToList());
        Save(Path.Combine(directoryPath,"Event.xml"), Event.EventList.ToList());
        Save(Path.Combine(directoryPath,"FanZone.xml"), FanZone.FanZoneList.ToList());
        Save(Path.Combine(directoryPath,"Female.xml"), Female.List.ToList());
        Save(Path.Combine(directoryPath,"Hiring.xml"), Hiring.List.ToList());
        Save(Path.Combine(directoryPath,"Location.xml"), Location.LocationList.ToList());
        Save(Path.Combine(directoryPath,"Male.xml"), Male.List.ToList());
        Save(Path.Combine(directoryPath,"Musical.xml"), Musical.MusicalList.ToList());
        Save(Path.Combine(directoryPath,"Order.xml"), Order.List.ToList());
        Save(Path.Combine(directoryPath,"Organizer.xml"), Organizer.OrganizerList.ToList());
        Save(Path.Combine(directoryPath,"Other.xml"), Other.OtherList.ToList());
        Save(Path.Combine(directoryPath,"Scene.xml"), Scene.SceneList.ToList());
        Save(Path.Combine(directoryPath,"Sport.xml"), Sport.SportList.ToList());
        Save(Path.Combine(directoryPath,"Stadium.xml"), Stadium.StadiumList.ToList());
        Save(Path.Combine(directoryPath,"Staff.xml"), Staff.StaffList.ToList());
        Save(Path.Combine(directoryPath,"Standard.xml"), Standard.StandardList.ToList());
        Save(Path.Combine(directoryPath,"Standup.xml"), Standup.StandupList.ToList());
        Save(Path.Combine(directoryPath,"Vip.xml"), Vip.VipList.ToList());
    }

    public static void LoadAllData()
    {
        Address.LoadExtent(Load<List<Address>>("Address.xml"));
        Club.LoadExtent(Load<List<Club>>("Club.xml"));
        Customer.LoadExtent(Load<List<Customer>>("Customer.xml"));
        Event.LoadExtent(Load<List<Event>>("Event.xml"));
        FanZone.LoadExtent(Load<List<FanZone>>("FanZone.xml"));
        Female.LoadExtent(Load<List<Female>>("Female.xml"));
        Hiring.LoadExtent(Load<List<Hiring>>("Hiring.xml"));
        Location.LoadExtent(Load<List<Location>>("Location.xml"));
        Male.LoadExtent(Load<List<Male>>("Male.xml"));
        Musical.LoadExtent(Load<List<Musical>>("Musical.xml"));
        Order.LoadExtent(Load<List<Order>>("Order.xml"));
        Organizer.LoadExtent(Load<List<Organizer>>("Organizer.xml"));
        Other.LoadExtent(Load<List<Other>>("Other.xml"));
        Scene.LoadExtent(Load<List<Scene>>("Scene.xml"));
        Sport.LoadExtent(Load<List<Sport>>("Sport.xml"));
        Stadium.LoadExtent(Load<List<Stadium>>("Stadium.xml"));
        Staff.LoadExtent(Load<List<Staff>>("Staff.xml"));
        Standard.LoadExtent(Load<List<Standard>>("Standard.xml"));
        Standup.LoadExtent(Load<List<Standup>>("Standup.xml"));
        Vip.LoadExtent(Load<List<Vip>>("Vip.xml"));
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