using System.Xml.Serialization;

namespace EventSystem.Classes;

public class Order
{
    private static readonly List<Order> _orderList = [];
    public static IReadOnlyList<Order> List => _orderList;
    
    public bool IsFinalized { get; set; } = false;
    
    [XmlIgnore]
    public decimal TotalPrice => TicketsInOrder.Sum(ticket => ticket.Price);

    [XmlIgnore]
    public static readonly int MaxTicketQuantity = 5;

    
    // Will be fixed later
    [XmlIgnore]
    public List<Ticket> TicketsInOrder { get; }
    [XmlIgnore]
    public Customer? CreatedByCustomer { get; }
    
    public Order(Customer createdByCustomer, List<Ticket> ticketsInOrder)
    {
        CreatedByCustomer = createdByCustomer;
        TicketsInOrder = ticketsInOrder;
        
        _orderList.Add(this);
    }

    public Order()
    {
        TicketsInOrder = new List<Ticket>();
    }
    
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