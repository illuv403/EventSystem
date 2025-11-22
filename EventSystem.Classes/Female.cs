namespace EventSystem.Classes;

public class Female : Person
{
    private char Symbol { get; }= '\u2640';

    public Female(string name, string surname, string email, string phoneNumber, DateTime birthDate) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        
    }

    
}