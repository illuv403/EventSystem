namespace EventSystem.Classes;

public abstract class Ticket
{
    public string GateNumber { get; }
    public decimal Price { get; }
    
    public Event EventForTicket { get; }
    public Order Order { get; }

    public Ticket(string gateNumber, decimal price, Event eventForTicket, Order order)
    {
        GateNumber = gateNumber;
        Price = price;
        
        EventForTicket = eventForTicket;
        Order = order;
    }
    
    
}