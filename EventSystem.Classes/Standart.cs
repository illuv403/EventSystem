namespace EventSystem.Classes;

public class Standart : Ticket
{
    private string _seatNumber;

    public Standart(string gateNumber, decimal price, string seatNumber, Event eveForTicket, Order order) : base(gateNumber, price, eveForTicket, order)
    {
        _seatNumber = seatNumber;
    }
}