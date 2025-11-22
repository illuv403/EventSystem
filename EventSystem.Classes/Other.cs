namespace EventSystem.Classes;

public class Other : Person
{
    private string _type;

    public Other(string name, string surname, string email, string phoneNumber, DateTime birthDate, string type)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        _type = type;
    }
}