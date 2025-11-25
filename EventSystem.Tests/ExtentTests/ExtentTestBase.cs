using EventSystem.Classes;

namespace EventSystem.Tests.ExtentTests;

public abstract class ExtentTestBase
{
    public ExtentTestBase()
    {
        Address.ClearExtent();
        Club.ClearExtent();
        Customer.ClearExtent();
        Event.ClearExtent();
        FanZone.ClearExtent();
        Female.ClearExtent();
        Hiring.ClearExtent();
        Location.ClearExtent();
        Male.ClearExtent();
        Musical.ClearExtent();
        Order.ClearExtent();
        Organizer.ClearExtent();
        Other.ClearExtent();
        Scene.ClearExtent();
        Sport.ClearExtent();
        Stadium.ClearExtent();
        Staff.ClearExtent();
        Standard.ClearExtent();
        Standup.ClearExtent();
        Vip.ClearExtent();
    }
}