using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public class EventExtentTests : ExtentTestBase
{
    [Fact]
    public void AddingToExtentTest()
    {
        var _event = TestData.Event();

        Assert.Single(Event.EventList);
        Assert.Equal(_event, Event.EventList[0]);
    }
    
    [Fact]
    public void LoadExtent_ReplaceExistingObjects()
    {
        var _event = TestData.Event();
        
        var newList = new List<Event>
        {
            new(_event.Title, new DateTime(2026, 06, 14), new DateTime(2026, 06, 24),
                _event.Description, _event.Organizers, _event.StaffAssigned, _event.InWhoseWishList, _event.Location, _event.TicketsForEvent, true, false, false)
        };
        
        Event.LoadExtent(newList);
        
        Assert.Single(Event.EventList);
        Assert.Equal(new DateTime(2026, 06, 14), Event.EventList[0].StartDateAndTime);
    }
}