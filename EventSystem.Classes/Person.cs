using System.ComponentModel.DataAnnotations;

namespace EventSystem.Classes;

public abstract class Person
{
    public string Name {get;}
    public string Surname {get;}
    public string Email {get;}
    public string PhoneNumber {get;}
    public DateOnly BirthDate {get;}
    

    public Person(string name, string surname, string email, string phoneNumber, DateOnly birthDate)
    {
        name = name.Trim();
        surname = surname.Trim();
        email = email.Trim();
        phoneNumber = phoneNumber.Trim();
        
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("Surname cannot be empty.");
        
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.");
        if (!new EmailAddressAttribute().IsValid(email))
            throw new ArgumentException("Invalid email address.");
        
        if (string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Phone number cannot be empty.");
        if (!new PhoneAttribute().IsValid(phoneNumber))
            throw new ArgumentException("Phone number is invalid.");
        
        if (birthDate > DateOnly.FromDateTime(DateTime.Now))
            throw new ArgumentException("Birth date is invalid.");
        
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    protected Person()
    {
        throw new NotImplementedException();
    }
}