namespace EventSystem.Classes;

public class Ticket
{
    private string _gateNumber;
    private decimal _price;
    
    private Event _eveForTicket;
    private Order _order;

    public Ticket(string gateNumber, decimal price, Event eveForTicket, Order order)
    {
        _gateNumber = gateNumber;
        _price = price;
        
        _eveForTicket = eveForTicket;
        _order = order;
    }
    
    
}