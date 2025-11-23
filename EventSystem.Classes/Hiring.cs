namespace EventSystem.Classes;

public class Hiring
{
    
    public Staff Stuff;
    public Organizer Organizer;
    public DateTime DateHired;
    public DateTime? DateFired;
    
    public Hiring(Staff stuff, Organizer organizer, DateTime dateHired, DateTime? dateFired)
    {
        Stuff = stuff;
        Organizer = organizer;
        DateHired = dateHired;
        DateFired = dateFired;
    }
}