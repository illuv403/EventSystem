using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Hiring
{
    private static readonly List<Hiring> _hiringList = [];
    public static IReadOnlyList<Hiring> List => _hiringList;
    
    [XmlIgnore]
    public Staff Staff;
    [XmlIgnore]
    public Organizer Organizer;
    public DateOnly DateHired;
    public DateOnly? DateFired;
    
    public Hiring(Staff staff, Organizer organizer, DateOnly dateHired, DateOnly? dateFired)
    {
        Staff = staff;
        Organizer = organizer;
        DateHired = dateHired;
        DateFired = dateFired;
        
        _hiringList.Add(this);
    }
    
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