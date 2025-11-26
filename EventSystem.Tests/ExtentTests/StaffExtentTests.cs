using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class StaffExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var staff = TestData.Staff();

        Assert.Single(Staff.StaffList);
        Assert.Equal(staff, Staff.StaffList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var staff = TestData.Staff();
        
        var newList = new List<Staff>
        {
            new(staff.Name, staff.Surname, "alecai.m@gmail.com", staff.PhoneNumber, staff.BirthDate, staff.Role, staff.Address, new decimal(2578.0), staff.Events, staff.Organizer, staff.Manager, staff.Subordinates)
        };
        
        Staff.LoadExtent(newList);
        
        Assert.Single(Staff.StaffList);
        Assert.Equal("alecai.m@gmail.com", Staff.StaffList[0].Email);
    }
}