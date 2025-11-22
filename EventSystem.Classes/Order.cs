namespace EventSystem.Classes;

public class Order
{
    private int _isFinalized;
    private decimal _totalPrice;
    private int _maxTicketQuantity = 5;
    
    private List<Ticket>? _ticketsInOrder; 
    
    //part of Customer Order association, may need additional fixes
    private Customer _ownedByCustomer;
    
    public Order(int isFinalized, decimal totalPrice, Customer ownedByCustomer)
    {
        _isFinalized = isFinalized;
        _totalPrice = totalPrice;
        
        //_ticketsInOrder.add(new Ticket())
        _ownedByCustomer = ownedByCustomer;
    }

    
}