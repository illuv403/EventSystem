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
    
    private HashSet<Ticket> _ticketsInOrder = new();
    public Order(Customer createdByCustomer, List<Ticket> ticketsInOrder)
    {
        CreatedByCustomer = createdByCustomer;
        
        
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
        
        if (_ticketsInOrder.Count + 1 > MaxTicketQuantity) throw new ArgumentException("Order cant hold more than 5 tickets.") ;
        
        _ticketsInOrder.Add(ticketToAdd);

    }

    public void RemoveTicketsInOrder(Ticket ticketToRemove)
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
            RemoveTicketsInOrder(ticket);
        }
    }

    public void UpdateInResponsibleForEvent(Ticket ticketToRemove, Ticket ticketToAdd)
    {   
        RemoveTicketsInOrder(ticketToAdd);
        AddTicketToOrder(ticketToRemove);
    }
}