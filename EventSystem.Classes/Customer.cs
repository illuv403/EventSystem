namespace EventSystem.Classes;

public class Customer : Person
{
    private ushort _age;
    private string _status;
    
    //part of Customer Order association, may need additional fixes
    private List<Order>? _orders;

    public Customer(string name, string surname, string email, string phoneNumber, DateTime birthDate, ushort age, string status,  List<Order>? orders) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        _age = age;
        _status = status;
        
        _orders = orders;
    }
}