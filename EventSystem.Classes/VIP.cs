namespace EventSystem.Classes;

public class VIP : Ticket
{
    private string _loungeNumber;
    
    public VIP(string gateNumber, decimal price, string loungeNumber, Event eveForTicket, Order order) : base(gateNumber, price, eveForTicket, order)
    {
        _loungeNumber = loungeNumber;
    }
}