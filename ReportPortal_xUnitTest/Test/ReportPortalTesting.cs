using FluentAssertions;
using ReportPortal_POM.Models;

namespace ReportPortal_xUnitTest.Test;

public class ReportPortalTesting : BaseTest
{
    [Fact]
    [Trait("Category", "Front")]
    public void TestLogin_Successfully()
    {
        var authModel = new AuthModel(PageFactory, Configuration, LogProvider).
            PerformLogin(Configuration["UserName"], Configuration["UserPassword"]);

        var dashboardModel = new DashboardModel(PageFactory, Configuration, LogProvider);
        
        dashboardModel.NavigateTo();
        dashboardModel.IsPageHeaderDisplayed().Should().BeTrue();
        dashboardModel.GetPageHeaderText().Should().BeEquivalentTo("ALL DASHBOARDS");
    }
}