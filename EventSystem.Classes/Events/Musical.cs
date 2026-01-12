namespace EventSystem.Classes;

public class Musical
{
    private static readonly List<Musical> _musicalList = [];
    public static IReadOnlyList<Musical> MusicalList => _musicalList;
    
    public string Artist { get; set; }
    public string Genre { get; set; }
    
    public Musical()
    {
    }

    public Musical(string Artist, string Genre)
    {
        this.Artist = Artist;
        this.Genre = Genre;
        _musicalList.Add(this);
    }
    
    public bool isGenre(string genre) => Genre == genre;
    public bool isArtist(string artist) => Artist == artist;

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
}