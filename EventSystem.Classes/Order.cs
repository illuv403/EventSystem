using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public class Order
{
    private static readonly List<Order> _orderList = [];
    public static IReadOnlyList<Order> List => _orderList;
    
    public bool IsFinalized { get; set; } = false;
    
    public decimal TotalPrice => TicketsInOrder.Sum(ticket => ticket.Price);
    
    public static readonly int MaxTicketQuantity = 5;

    
    // Will be fixed later
    [JsonInclude]
    public List<Ticket> TicketsInOrder { get; private set; }
    [JsonInclude]
    public Customer? CreatedByCustomer { get; private set; }
    
    public Order(Customer createdByCustomer, List<Ticket> ticketsInOrder)
    {
        CreatedByCustomer = createdByCustomer;
        TicketsInOrder = ticketsInOrder;
        
        _orderList.Add(this);
    }

    public Order() { }
    
    public static void LoadExtent(List<Order>? list)
    {
        _orderList.Clear();
        
        if(list != null)
            _orderList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _orderList.Clear();   
    }
}