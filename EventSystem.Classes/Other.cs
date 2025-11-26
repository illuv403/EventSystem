namespace EventSystem.Classes;

public class Other : Person
{
    private static readonly List<Other> _otherList = [];
    public static IReadOnlyList<Other> OtherList => _otherList;

    public string Type { get; set; } = "None";

    public Other(string name, string surname, string email, string phoneNumber, DateOnly birthDate, string type)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        if (!string.IsNullOrEmpty(type))
            Type = type;
        
        _otherList.Add(this);
    }

    public Other() : base()
    {
    }

    public static void LoadExtent(List<Other>? list)
    {
        _otherList.Clear();
        
        if(list != null)
            _otherList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _otherList.Clear();   
    }
}