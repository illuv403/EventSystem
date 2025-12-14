using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public class Order
{
    private static readonly List<Order> _orderList = [];
    public static IReadOnlyList<Order> List => _orderList;
    
    public string OrderId { get; private set; }
    
    public bool IsFinalized { get; set; } = false;
    
    public decimal TotalPrice => TicketsInOrder.Sum(ticket => ticket.Price);
    
    public static readonly int MaxTicketQuantity = 5;

    
    // Will be fixed later
    [JsonInclude]
    public List<Ticket> TicketsInOrder { get; private set; }
    [JsonInclude]
    public Customer? CreatedByCustomer { get; private set; }
    
    private HashSet<Ticket> _ticketsInOrder = new();
    private Customer? _createdByCustomer;
    
    public Order(string orderId, Customer createdByCustomer, List<Ticket> ticketsInOrder)
    {
        OrderId = orderId;
        
        CreatedByCustomer = createdByCustomer;
        _createdByCustomer = createdByCustomer;
        
        foreach (Ticket ticket in ticketsInOrder)
        {
            AddTicketToOrder(ticket);
        }
        
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
    
    public HashSet<Ticket> GetTicketsInOrder()
    {
        return [.._ticketsInOrder];
    }

    public void AddTicketToOrder(Ticket ticketToAdd)
    {
        if (_ticketsInOrder.Contains(ticketToAdd))  return;
        
        if (_ticketsInOrder.Count == MaxTicketQuantity) throw new ArgumentException("Order cant hold more than 5 tickets.");
        
        _ticketsInOrder.Add(ticketToAdd);

    }

    public void RemoveTicketFromOrder(Ticket ticketToRemove)
    {
        if (!_ticketsInOrder.Contains(ticketToRemove))  return;
        
        _ticketsInOrder.Remove(ticketToRemove);
        ticketToRemove.Dispose();
    }

    //Maybe should be fixed
    public void DeleteOrderTickets()
    {
        foreach (Ticket ticket in _ticketsInOrder)
        {
            RemoveTicketFromOrder(ticket);
        }
    }

    public void UpdateTicketsInOrder(Ticket ticketToRemove, Ticket ticketToAdd)
    {   
        RemoveTicketFromOrder(ticketToRemove);
        AddTicketToOrder(ticketToAdd);
    }

    public Customer? GetCreatedByCustomer()
    {
        return _createdByCustomer;
    }
    
    public void AddToCustomer(Customer customer)
    {
        if (_createdByCustomer == customer)
            return;
        
        _createdByCustomer = customer;
        customer.AddCustomerOrder(this);
    }

    public void RemoveFromCustomer()
    {
        if  (_createdByCustomer == null)
            return;
        
        var customer = _createdByCustomer;
        _createdByCustomer = null;
        customer.RemoveCustomerOrder(this);
    }

    public void UpdateCustomerOrder(string newOrderId)
    {
        if (_createdByCustomer == null)
            throw new Exception("You cannot update customer orders when there is no customer assigned.");

        string orderId = OrderId;
        OrderId = newOrderId;
        
        _createdByCustomer.UpdateCustomerOrder(orderId, newOrderId, this);
    }
}