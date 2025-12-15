using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace EventSystem.Classes;

public abstract class Ticket : IDisposable
{   
    private bool _isDisposed;
    public string GateNumber { get; set; }
    public decimal Price { get; set; }
    
    [JsonInclude]
    public Event EventForTicket { get; private set; }
    
    [JsonInclude]
    public Order Order { get; private set; }

    private Event _createdForEvent;
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
        _createdForEvent = eventForTicket;
        _createdForEvent.AddTicket(this);
        Order = order;
        order.AddTicketToOrder(this);
    }
    
    public Ticket() { }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;
        _isDisposed = true;

        if (disposing)
        {
            Order = null;
            EventForTicket = null;
        }
    }

    public Event GetEventForTicket()
    {
        return _createdForEvent;
    }

    public void UpdateEvent(Event newEvent)
    {
        newEvent.UpdateTicket(this);
    }
}