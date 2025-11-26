using System.Text.Json;
using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public static class Persistence
{
    private static string DataDirectory = "Data";

    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        PropertyNameCaseInsensitive = true,
        IncludeFields = false
    };
    
    public static void SaveAllData(string directoryPath = null)
    {
        if (directoryPath != null) DataDirectory = directoryPath;
        if (!Directory.Exists(DataDirectory)) Directory.CreateDirectory(DataDirectory);
        
        Save("addresses.json", Address.AddressList.ToList());
        Save("clubs.json", Club.ClubList.ToList());
        Save("customers.json", Customer.CustomerList.ToList());
        Save("events.json", Event.EventList.Where(e => e.GetType() == typeof(Event)).ToList());
        Save("fanzone.json", FanZone.FanZoneList.ToList());
        Save("female.json", Female.List.ToList());
        Save("hiring.json", Hiring.List.ToList());
        Save("locations.json", Location.LocationList.Where(l => l.GetType() == typeof(Location)).ToList());
        Save("male.json", Male.List.ToList());
        Save("musicals.json", Musical.MusicalList.ToList());
        Save("orders.json", Order.List.ToList());
        Save("organizers.json", Organizer.OrganizerList.ToList());
        Save("other.json", Other.OtherList.ToList());
        Save("scenes.json", Scene.SceneList.ToList());
        Save("sports.json", Sport.SportList.ToList());
        Save("stadiums.json", Stadium.StadiumList.ToList());
        Save("staff.json", Staff.StaffList.ToList());
        Save("standard.json", Standard.StandardList.ToList());
        Save("standup.json", Standup.StandupList.ToList());
        Save("vip.json", Vip.VipList.ToList());
    }
    
    public static void LoadAllData(string directoryPath = null)
    {
        if (directoryPath != null) DataDirectory = directoryPath;
        
        Address.LoadExtent(Load<List<Address>>("addresses.json"));
        
        Location.LoadExtent(Load<List<Location>>("locations.json"));
        Club.LoadExtent(Load<List<Club>>("clubs.json"));
        Scene.LoadExtent(Load<List<Scene>>("scenes.json"));
        Stadium.LoadExtent(Load<List<Stadium>>("stadiums.json"));

        Female.LoadExtent(Load<List<Female>>("female.json"));
        Male.LoadExtent(Load<List<Male>>("male.json"));
        Other.LoadExtent(Load<List<Other>>("other.json"));
        Customer.LoadExtent(Load<List<Customer>>("customers.json"));
        Organizer.LoadExtent(Load<List<Organizer>>("organizers.json"));
        Staff.LoadExtent(Load<List<Staff>>("staff.json"));

        Event.LoadExtent(Load<List<Event>>("events.json"));
        Musical.LoadExtent(Load<List<Musical>>("musicals.json") );
        Sport.LoadExtent(Load<List<Sport>>("sports.json"));
        Standup.LoadExtent(Load<List<Standup>>("standup.json"));

        FanZone.LoadExtent(Load<List<FanZone>>("fanzone.json"));
        Standard.LoadExtent(Load<List<Standard>>("standard.json"));
        Vip.LoadExtent(Load<List<Vip>>("vip.json"));
        
        Order.LoadExtent(Load<List<Order>>("orders.json"));

        Hiring.LoadExtent(Load<List<Hiring>>("hiring.json"));
    }

    private static void Save<T>(string fileName, T data)
    {
        var filePath = Path.Combine(DataDirectory, fileName);
        try
        {
            var json = JsonSerializer.Serialize(data, Options);
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to save {fileName}: {ex.Message}");
        }
    }

    private static T? Load<T>(string fileName)
    {
        var filePath = Path.Combine(DataDirectory, fileName);
        if (!File.Exists(filePath))
            return default;
        try
        {
            var json = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(json))
            {
                return default;
            }

            var res = JsonSerializer.Deserialize<T>(json, Options);
            return res ?? default;
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Failed to deserialize {fileName}: {ex.Message}");
        }
    }
}