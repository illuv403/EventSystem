using System.Text.Json.Serialization;
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
    
    public int Age => 
        DateTime.Now.Year - BirthDate.Year - (DateTime.Now.DayOfYear - BirthDate.DayOfYear < 0 ? 1 : 0);

    public CustomerStatus Status { get; set; } = CustomerStatus.Active;
    

    // Will be fixed later (should be Map)
    [JsonInclude]
    public List<Order> Orders { get; private set; }

    private HashSet<Event> _wishesForEvent = new();
    
    public Customer(string name, string surname, string email, 
        string phoneNumber, DateOnly birthDate, List<Order> orders) 
        : base(name, surname, email, phoneNumber, birthDate)
    {
        Orders = orders;
        
        _customerList.Add(this);
    }

    public Customer() { } 

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

    public HashSet<Event> WishesForEvent()
    {
        return [.._wishesForEvent];
    }

    public void AddWishForEvent(Event eventToAdd)
    {
        if (_wishesForEvent.Contains(eventToAdd)) return;
        
        _wishesForEvent.Add(eventToAdd);
        eventToAdd.AddInWishList(this);
    }

    public void RemoveWishForEvent(Event eventToRemove)
    {
        if (!_wishesForEvent.Contains(eventToRemove)) return;
        
        _wishesForEvent.Remove(eventToRemove);
        eventToRemove.RemoveInWishList(this);
    }

    public void UpdateWishesForEvent(Event eventToRemove, Event eventToAdd)
    {
        RemoveWishForEvent(eventToRemove);
        AddWishForEvent(eventToAdd);
    }
}