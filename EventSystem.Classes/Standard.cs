namespace EventSystem.Classes;

public class Standard : Ticket
{
    private static readonly List<Standard> _standardList = [];
    public static IReadOnlyList<Standard> StandardList => _standardList;
    
    public string SeatNumber { get; }

    public Standard(string gateNumber, decimal price, string seatNumber, Event eventForTicket, Order order) 
        : base(gateNumber, price, eventForTicket, order)
    {
        SeatNumber = seatNumber;
        
        _standardList.Add(this);
    }
    
    public static void LoadExtent(List<Standard>? list)
    {
        _standardList.Clear();
        
        if(list != null)
            _standardList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _standardList.Clear();   
    }
}