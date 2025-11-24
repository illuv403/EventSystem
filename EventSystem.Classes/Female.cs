namespace EventSystem.Classes;

public class Female : Person
{
    private static readonly List<Female> _femaleList = [];
    public static IReadOnlyList<Female> List => _femaleList;
    
    public const char Symbol = '\u2640';

    public Female(string name, string surname, string email, string phoneNumber, DateOnly birthDate) 
        :base(name, surname, email, phoneNumber, birthDate)
    {
        _femaleList.Add(this);
    }

    public char GetSymbol()
    {
        return Symbol;
    }
    
    public static void LoadExtent(List<Female>? list)
    {
        _femaleList.Clear();
        
        if(list != null)
            _femaleList.AddRange(list);
    }
}