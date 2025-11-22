namespace EventSystem.Classes;

public class Order
{
    public int? IsFinalized { get; }
    public decimal TotalPrice { get; } = 0;

    public int MaxTicketQuantity { get; } = 5;

    public List<Ticket>? TicketsInOrder { get; } = new();
    
    //part of Customer Order association, may need additional fixes
    public Customer OwnedByCustomer { get; }
    
    public Order(int? isFinalized, Customer ownedByCustomer)
    {
        IsFinalized = isFinalized;
        OwnedByCustomer = ownedByCustomer;
    }

    
}