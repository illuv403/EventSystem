using System.Text.Json.Serialization;

namespace EventSystem.Classes;

public class Address
{
    private static readonly List<Address> _addressList = [];
    public static IReadOnlyList<Address> AddressList => _addressList;

    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string AppNumber { get; set; }
    public string Index { get; set; }
    
    [JsonInclude]
    public List<Staff> Staff { get; private set; }

    private HashSet<Staff> _staffLivingHere = new();
    
    public Address(string country, string city, string street, string appNumber, string index, List<Staff> staff)
    {
        country = country.Trim();
        city = city.Trim();
        street = street.Trim();
        appNumber = appNumber.Trim();
        index = index.Trim();
        
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be empty.");
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be empty.");
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be empty.");
        if (string.IsNullOrWhiteSpace(appNumber))
            throw new ArgumentException("App number cannot be empty.");
        if (string.IsNullOrWhiteSpace(index))
            throw new ArgumentException("Index cannot be empty.");
        
        Country = country;
        City = city;
        Street = street;
        AppNumber = appNumber;
        Index = index;
        
        Staff = staff;
        foreach (Staff staffMember in staff)
        {
            _staffLivingHere.Add(staffMember);
        }
        
        _addressList.Add(this);
    }
    
    public Address() { }
    
    public static void LoadExtent(List<Address>? list)
    {
        _addressList.Clear();
        
        if(list != null) 
            _addressList.AddRange(list);
    }

    public static void ClearExtent()
    {
        _addressList.Clear();
    }
    
    //Should be changed if Address in Staff CAN be null
    public void AddStaffLivingHere(Staff staffToAdd)
    {
        if (_staffLivingHere.Contains(staffToAdd)) return;
        
        _staffLivingHere.Add(staffToAdd);
        staffToAdd.UpdateAccommodationAddress(this);
    }

    public void RemoveStaffLivingHere(Staff staffToRemove, Address newAccommodationAddress)
    {
        if (!_staffLivingHere.Contains(staffToRemove)) return;
        
        _staffLivingHere.Remove(staffToRemove);
        staffToRemove.UpdateAccommodationAddress(newAccommodationAddress);
    }
    
    public HashSet<Staff> GetStaffLivingHere()
    {
        return [.._staffLivingHere];
    }
}