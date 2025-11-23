
namespace EventSystem.Classes;

public abstract class Person
{
    public string Name {get;}
    public string Surname {get;}
    public string Email {get;}
    public string PhoneNumber {get;}
    public DateTime BirthDate {get;}

    public Person(string name, string surname, string email, string phoneNumber, DateTime birthDate)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }
}