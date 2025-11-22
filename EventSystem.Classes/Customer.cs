namespace EventSystem.Classes;

public class Customer : Person
{
    public int Age { get; } = 0;
    
    public enum CustomerStatus
    {
        Active = 0,
        Suspended = 1,
        Deleted = 2
    }
    public CustomerStatus Status { get; }
    

    //part of Customer Order association, may need additional fixes
    public List<Order>? Orders { get; } = new();

    public Customer(string name, string surname, string email, string phoneNumber, DateTime birthDate, int status,  List<Order>? orders) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        Status = (CustomerStatus)status;
        
        Orders = orders;
    }

    
}