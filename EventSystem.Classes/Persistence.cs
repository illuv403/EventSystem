using System.Xml.Serialization;

namespace EventSystem.Classes;

public static class Persistence
{
    public static void SaveAllData()
    {
        Save("Address.xml", Address.AddressList.ToList());
        Save("Club.xml", Club.ClubList.ToList());
        Save("Customer.xml", Customer.CustomerList.ToList());
        Save("Event.xml", Event.EventList.ToList());
        Save("FanZone.xml", FanZone.FanZoneList.ToList());
        Save("Female.xml", Female.List.ToList());
        Save("Hiring.xml", Hiring.List.ToList());
        Save("Location.xml", Location.LocationList.ToList());
        Save("Male.xml", Male.List.ToList());
        Save("Musical.xml", Musical.MusicalList.ToList());
        Save("Order.xml", Order.List.ToList());
        Save("Organizer.xml", Organizer.OrganizerList.ToList());
        Save("Other.xml", Other.OtherList.ToList());
        Save("Scene.xml", Scene.SceneList.ToList());
        Save("Sport.xml", Sport.SportList.ToList());
        Save("Stadium.xml", Stadium.StadiumList.ToList());
        Save("Staff.xml", Staff.StaffList.ToList());
        Save("Standard.xml", Standard.StandardList.ToList());
        Save("Standup.xml", Standup.StandupList.ToList());
        Save("Vip.xml", Vip.VipList.ToList());
    }
    
    private static void Save<T>(string fileName, T data)
    {
        using var writer = new StreamWriter(fileName);
        var serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(writer, data);
    }
}