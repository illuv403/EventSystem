namespace EventSystem.Classes;

public class Other : Person
{
    public string Type { get; }

    public Other(string name, string surname, string email, string phoneNumber, DateTime birthDate, string type)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Type = type;
    }
}