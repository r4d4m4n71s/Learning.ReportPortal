using ReportPortal_POM.Models;
using ReportPortal_POM.Util;

namespace ReportPortal_xUnitTest.Test;

public class ReportPortalTesting : BaseTest
{
    [Fact]
    public void TestLogin_Ok()
    {
        _ = new AuthModel(PageFactory, Configuration, LogProvider).
            PerformLogin(Configuration["UserName"], Configuration["UserPassword"])
            .GetModel<DashboardModel>().IsDashboardOpen();
        LogProvider.GetLogger<ReportPortalTesting>().Info("Login test ok!.");
    }
}