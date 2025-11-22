namespace EventSystem.Classes;

public class VIP : Ticket
{
    public string LoungeNumber { get; }
    
    public VIP(string gateNumber, decimal price, string loungeNumber, Event eventForTicket, Order order) : base(gateNumber, price, eventForTicket, order)
    {
        LoungeNumber = loungeNumber;
    }
}