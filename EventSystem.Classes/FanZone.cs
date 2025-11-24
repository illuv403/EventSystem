namespace EventSystem.Classes;

public class FanZone : Ticket
{
    private static readonly List<FanZone> _fanZoneList = [];
    public static IReadOnlyList<FanZone> FanZoneList => _fanZoneList;
    
    public FanZone(string gateNumber, decimal price, Event eveForTicket, Order order) : base(gateNumber, price, eveForTicket, order)
    {
        _fanZoneList.Add(this);
    }
}