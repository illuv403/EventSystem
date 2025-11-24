namespace EventSystem.Classes;

public class Vip : Ticket
{
    private static readonly List<Vip> _vipList = [];
    public static IReadOnlyList<Vip> VipList => _vipList;
    
    public string LoungeNumber { get; }
    
    public Vip(string gateNumber, decimal price, string loungeNumber, Event eventForTicket, Order order)
        : base(gateNumber, price, eventForTicket, order)
    {
        LoungeNumber = loungeNumber;
        
        _vipList.Add(this);
    }
}