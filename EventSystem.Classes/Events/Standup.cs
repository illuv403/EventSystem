namespace EventSystem.Classes;

public class Standup
{
    private static readonly List<Standup> _standupList = [];
    public static IReadOnlyList<Standup> StandupList => _standupList;
    
    public string Comedian { get; set; }
    public string ComedyStyle { get; set; }
    public bool IsMatureContent { get; set; }
    public int MinimumAge { get; set; }
    
    public Standup() 
    {
    }

    public Standup(string Comedian, string ComedyStyle, bool isMatureContent, int MinimumAge)
    {
        this.Comedian = Comedian;
        this.ComedyStyle = ComedyStyle;
        this.IsMatureContent = isMatureContent;
        this.MinimumAge = MinimumAge;
        _standupList.Add(this);
    }
    
    public bool IsSuitableForAge(int age) => age >= MinimumAge;
    
    public static void LoadExtent(List<Standup>? list)
    {
        _standupList.Clear();
        
        if(list != null)
            _standupList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _standupList.Clear();   
    }
}