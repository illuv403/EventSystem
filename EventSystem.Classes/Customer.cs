using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Customer : Person
{
    private static readonly List<Customer> _customerList = [];
    public static IReadOnlyList<Customer> CustomerList => _customerList;
    
    public enum CustomerStatus
    {
        Active,
        Suspended,
        Deleted
    }
    
    [XmlIgnore]
    public int Age => 
        DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear - BirthDate.DayOfYear < 0 ? 1 : 0);

    public CustomerStatus Status { get; } = CustomerStatus.Active;
    

    // Will be fixed later (should be Map)
    public List<Order> Orders { get; }
    
    public Customer(string name, string surname, string email,
        string phoneNumber, DateOnly birthDate)
        : base(name, surname, email, phoneNumber, birthDate)
    {
    }

    public Customer(string name, string surname, string email, 
        string phoneNumber, DateOnly birthDate, List<Order> orders) 
        : base(name, surname, email, phoneNumber, birthDate)
    {
        Orders = orders;
        
        _customerList.Add(this);
    }

    public static void LoadExtent(List<Customer>? list)
    {
        _customerList.Clear();
        
        if(list != null)
            _customerList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _customerList.Clear();
    }
}