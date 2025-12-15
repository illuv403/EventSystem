using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Hiring
{
    private static readonly List<Hiring> _hiringList = [];
    public static IReadOnlyList<Hiring> List => _hiringList;
    
    [JsonInclude]
    public Staff Staff;
    [JsonInclude]
    public Organizer Organizer;
    public DateOnly DateHired;
    public DateOnly? DateFired;
    
    private Staff _staff;
    private Organizer _organizer;
    
    public Hiring(Staff staff, Organizer organizer, DateOnly dateHired, DateOnly? dateFired)
    {
        Staff = staff;
        Organizer = organizer;
        DateHired = dateHired;
        DateFired = dateFired;
        
        _staff = staff;
        _organizer = organizer;
        
        _hiringList.Add(this);
    }
    
    public Hiring() { }
    
    public static void LoadExtent(List<Hiring>? list)
    {
        _hiringList.Clear();
        
        if(list != null)
            _hiringList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _hiringList.Clear();   
    }
}