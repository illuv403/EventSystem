namespace EventSystem.Classes;

public class Male : Person
{
    private static readonly List<Male> _maleList = [];
    public static IReadOnlyList<Male> List => _maleList;
    
    public const char Symbol = '\u2642';

    public Male(string name, string surname, string email, string phoneNumber, DateOnly birthDate)
        :base(name, surname, email, phoneNumber, birthDate)
    {
        _maleList.Add(this);
    }

    public Male() : base()
    {
    }

    public char GetSymbol()
    {
        return Symbol;
    }
    
    public static void LoadExtent(List<Male>? list)
    {
        _maleList.Clear();
        
        if(list != null)
            _maleList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _maleList.Clear();   
    }
}