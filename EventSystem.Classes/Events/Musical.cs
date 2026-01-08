namespace EventSystem.Classes;

public class Musical
{
    // Just a variable for example , no need to add to diagram
    private string band = String.Empty;
    
    private static readonly List<Musical> _musicalList = [];
    public static IReadOnlyList<Musical> MusicalList => _musicalList;
    
    public Musical()
    
    {
        _musicalList.Add(this);
    }

    public static void LoadExtent(List<Musical>? list)
    {
        _musicalList.Clear();
        if(list != null)
            _musicalList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _musicalList.Clear();   
    }

    // method to get parameter
    public string GetBand()
    {
        return band;
    }
}