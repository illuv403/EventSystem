using System.Net;

namespace EventSystem.Classes;

public class Sport
{
    private static readonly List<Sport> _sportList = [];
    public static IReadOnlyList<Sport> SportList => _sportList;
    
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
    public string League { get; set; }
    public string SportType { get; set; }
    
    public Sport() 
    {
    }

    public Sport(string HomeTeam, string AwayTeam, string League, string SportType)
    {
        this.HomeTeam = HomeTeam;
        this.AwayTeam = AwayTeam;
        this.League = League;
        this.SportType = SportType;
        _sportList.Add(this);
    }
    
    public string GetMatchup() => $"{SportType} | {HomeTeam} vs {AwayTeam} | {League}";
    
    public static void LoadExtent(List<Sport>? list)
    {
        _sportList.Clear();
        
        if(list != null)
            _sportList.AddRange(list);
    }
    
    public static void ClearExtent()
    {
        _sportList.Clear();   
    }
}