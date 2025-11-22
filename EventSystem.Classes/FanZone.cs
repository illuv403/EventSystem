namespace EventSystem.Classes;

public class FanZone : Ticket
{
    public FanZone(string gateNumber, decimal price, Event eveForTicket, Order order) : base(gateNumber, price, eveForTicket, order)
    {
        
    }
}