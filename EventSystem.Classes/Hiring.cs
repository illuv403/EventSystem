using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Hiring : IDisposable
{
    private bool _isDisposed;
    
    private static readonly List<Hiring> _hiringList = [];
    public static IReadOnlyList<Hiring> List => _hiringList;
    
    [JsonInclude]
    public Staff Staff;
    [JsonInclude]
    public Organizer Organizer;
    public DateOnly DateHired;
    public DateOnly? DateFired;
    
    public Hiring(Staff staff, Organizer organizer, DateOnly dateHired, DateOnly? dateFired = null)
    {
        Staff = staff;
        Organizer = organizer;
        DateHired = dateHired;
        DateFired = dateFired;
        
        _hiringList.Add(this);
    }
    
    public Hiring() { }

    public void Fire(DateOnly dateFired)
    {
        if (DateFired is not null)
            throw new InvalidOperationException("Has already been fired.");
        
        DateFired = dateFired;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;
        _isDisposed = true;

        if (disposing)
        {
            Organizer.RemoveHiring(this);
            Staff.RemoveHiring(this);

            _hiringList.Remove(this);
        }
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