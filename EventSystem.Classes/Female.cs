namespace EventSystem.Classes;

public class Female : Person
{
    private const char _symbol = '\u2640';

    public Female(string name, string surname, string email, string phoneNumber, DateTime birthDate) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        
    }
}