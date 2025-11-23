namespace EventSystem.Classes;

public class Male : Person
{
    private char Symbol { get; } = '\u2642';

    public Male(string name, string surname, string email, string phoneNumber, DateTime birthDate, string type)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        
    }
}