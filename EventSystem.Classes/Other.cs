namespace EventSystem.Classes;

public class Other : Person
{
    private static readonly List<Other> _otherList = [];
    public static IReadOnlyList<Other> OtherList => _otherList;

    public string Type { get; } = "None";

    public Other(string name, string surname, string email, string phoneNumber, DateOnly birthDate, string type)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        if (!string.IsNullOrEmpty(type))
            Type = type;
        
        _otherList.Add(this);
    }
}