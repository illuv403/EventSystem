namespace EventSystem.Classes;

public class Vip : Ticket
{
    private static readonly List<Vip> _vipList = [];
    public static IReadOnlyList<Vip> VipList => _vipList;
    
    public string LoungeNumber { get; set; }
    
    public Vip(string gateNumber, decimal price, string loungeNumber, Event eventForTicket, Order order)
        : base(gateNumber, price, eventForTicket, order)
    {
        LoungeNumber = loungeNumber;
        
        _vipList.Add(this);
    }

    public static void LoadExtent(List<Vip>? list)
    {
        _vipList.Clear();
        
        if(list != null)
            _vipList.AddRange(list);
    }

    public Vip() { }

    public static void ClearExtent()
    {
        _vipList.Clear();   
    }
}