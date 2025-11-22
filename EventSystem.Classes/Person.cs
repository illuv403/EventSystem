using System.Runtime.InteropServices.JavaScript;

namespace EventSystem.Classes;

public class Person
{
    private string _name;
    private string _surname;
    private string _email;
    private string _phoneNumber;
    private DateTime _birthDate;

    public Person(string name, string surname, string email, string phoneNumber, DateTime birthDate)
    {
        _name = name;
        _surname = surname;
        _email = email;
        _phoneNumber = phoneNumber;
        _birthDate = birthDate;
    }
}