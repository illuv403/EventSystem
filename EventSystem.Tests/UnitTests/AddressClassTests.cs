using EventSystem.Classes;

namespace EventSystem.Tests;

public class AddressClassTests
{
   private Address _address; 
   
   private Address _address2; 
   
   private Staff _staff;

   public AddressClassTests()
   {
      _address = new Address("Poland", "Warsaw",
           "Al. Wilanowska 12", "125", "02-123", new List<Staff>());
       
      _address2 = new Address("Poland", "Warsaw",
          "St. Wolska 5", "1", "611", new List<Staff>());
      
      _staff = new Staff("Henry", "Grey",
          "test@gmail.com", "+48573370352", new DateOnly(2000, 1, 1),
          Staff.StaffRole.Bartender, _address, 599.99m, new List<Event>(),
          new Organizer("Anne", "Grey",
              "test@gmail.com", "+48573370352",
              new DateOnly(2000, 1, 1), 19999.99m, new List<Staff>(), new List<Event>()), new DateOnly(2000, 2, 1),
          null, new List<Staff>());
   }
    [Fact]
    public void AddressCreationTest()
    {
        Assert.Equal("Poland", _address.Country);
        Assert.Equal("Warsaw", _address.City);
        Assert.Equal("Al. Wilanowska 12", _address.Street);
        Assert.Equal("125", _address.AppNumber);
        Assert.Equal("02-123", _address.Index);
        Assert.Equal(new List<Staff>(), _address.Staff);
    }
    
    [Fact]
    public void AddressCountryNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("", "Warsaw",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>()));
        Assert.Equal("Country cannot be empty.", ex.Message);
    }

    [Fact]
    public void AddressCityNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "",
            "Al. Wilanowska 12", "125", "02-123", new List<Staff>())); 
        Assert.Equal("City cannot be empty.", ex.Message);
    }

    [Fact]
    public void AddressStreetNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "", "125", "02-123", new List<Staff>())); 
        Assert.Equal("Street cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void AddressAppNumberNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "", "02-123", new List<Staff>())); 
        Assert.Equal("App number cannot be empty.", ex.Message);
    }
    
    [Fact]
    public void AddressIndexNotGivenTest()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Address("Poland", "Warsaw",
            "Al. Wilanowska 12", "125", "", new List<Staff>())); 
        Assert.Equal("Index cannot be empty.", ex.Message);
    }

    [Fact]
    public void AddStaffLivingHereTest()
    {
        _address2.AddStaffLivingHere(_staff);
        
        Assert.Equal(_address2, _staff.GetAccommodationAddress());
        Assert.DoesNotContain(_staff, _address.GetStaffLivingHere());
        Assert.Contains(_staff, _address2.GetStaffLivingHere());
    }
    
    [Fact]
    public void RemoveStaffLivingHereTest()
    {
        _address.RemoveStaffLivingHere(_staff, _address2);
        
        Assert.Equal(_address2, _staff.GetAccommodationAddress());
        Assert.DoesNotContain(_staff, _address.GetStaffLivingHere());
        Assert.Contains(_staff, _address2.GetStaffLivingHere());
    }
}