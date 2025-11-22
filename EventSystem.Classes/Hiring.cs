namespace EventSystem.Classes;

public class Hiring
{
    
    private Staff _stuff;
    private Organizer _organizer;
    private DateTime _dateHired;
    private int _dateFired;
    
    public Hiring(Staff stuff, Organizer organizer, DateTime dateHired, int dateFired)
    {
        _stuff = stuff;
        _organizer = organizer;
        _dateHired = dateHired;
        _dateFired = dateFired;
    }
}