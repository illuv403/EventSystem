using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace EventSystem.Classes;

[XmlInclude(typeof(Male))]
[XmlInclude(typeof(Female))]
[XmlInclude(typeof(Other))]
[XmlInclude(typeof(Customer))]
[XmlInclude(typeof(Organizer))]
[XmlInclude(typeof(Staff))]
public abstract class Person
{
    public string Name {get; set; }
    public string Surname {get; set; }
    public string Email {get; set; }
    public string PhoneNumber {get; set; }
    public DateOnly BirthDate {get; set; }
    

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

    public Person()
    {
    }
}