using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public abstract class Ticket
{
    public string GateNumber { get; set; }
    public decimal Price { get; set; }
    
    [JsonIgnore]
    public Event EventForTicket { get; }
    
    [JsonIgnore]
    public Order Order { get; }

    public Ticket(string gateNumber, decimal price, Event eventForTicket, Order order)
    {
        gateNumber = gateNumber.Trim();
        
        if (string.IsNullOrWhiteSpace(gateNumber))
            throw new ArgumentException("Gate number cannot be empty.");
        
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");
        
        GateNumber = gateNumber;
        Price = price;
        
        EventForTicket = eventForTicket;
        Order = order;
    }

    public Ticket()
    {
        
    } 
    
}