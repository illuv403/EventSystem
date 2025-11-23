namespace EventSystem.Classes;

public class Standart : Ticket
{
    public string SeatNumber { get; }

    public Standart(string gateNumber, decimal price, string seatNumber, Event eventForTicket, Order order) : base(gateNumber, price, eventForTicket, order)
    {
        SeatNumber = seatNumber;
    }
}