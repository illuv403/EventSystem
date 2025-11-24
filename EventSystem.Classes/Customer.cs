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

    public int Age => 
        DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear - BirthDate.DayOfYear < 0 ? 1 : 0);

    public CustomerStatus Status { get; } = CustomerStatus.Active;
    

    // Will be fixed later (should be Map)
    public List<Order> Orders { get; }

    public Customer(string name, string surname, string email, 
        string phoneNumber, DateOnly birthDate, List<Order> orders) 
        : base(name, surname, email, phoneNumber, birthDate)
    {
        Orders = orders;
        
        _customerList.Add(this);
    }

    
}