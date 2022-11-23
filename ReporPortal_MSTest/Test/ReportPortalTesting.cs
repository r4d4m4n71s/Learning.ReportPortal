using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportPortal_MSTest.Util;
using ReportPortal_POM.Models;
using ReportPortal_POM.Util;

namespace ReportPortal_MSTest.Test;

[TestClass]
public class ReportPortalTesting : BaseTest
{
    [TestMethod]
    [TestCategory("Front")]
    public void TestLogin_Ok()
    {
        _ = new AuthModel(PageFactory, Configuration, LogProvider).
            PerformLogin(Configuration["UserName"], Configuration["UserPassword"])
            .GetModel<DashboardModel>().IsDashboardOpen();
        LogProvider.GetLogger<ReportPortalTesting>().Info("Login test ok!.");
    }

    [TestMethod]
    [TestCategory("Front")]
    [TestCategory("Data")]
    [TestDataSource("TestData/Launches.csv",typeof(CsvDataProvider))]
    public void TestLaunches_Ok(IDictionary<string, object> launchScenario)
    {
        TestLogin_Ok();

        _ = new LaunchesModel(PageFactory, Configuration, LogProvider).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "TOTAL", launchScenario["TOTAL"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "PASSED", launchScenario["PASSED"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "FAILED", launchScenario["FAILED"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "SKIPPED", launchScenario["SKIPPED"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "PRODUCT BUG", launchScenario["PRODUCT BUG"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "AUTO BUG", launchScenario["AUTO BUG"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "SYSTEM ISSUE", launchScenario["SYSTEM ISSUE"].ToString()).
            ValidateCellValues(Convert.ToInt32(launchScenario["LAUNCH"]), "TO INVESTIGATE", launchScenario["TO INVESTIGATE"].ToString());
    }

    [TestMethod]
    [TestCategory("Front")]
    [TestCategory("Data")]
    [TestDataSource("TestData/LaunchXSuites.csv", typeof(CsvDataProvider))]
    public void TestLaunchXSuites_Ok(IDictionary<string, object> suiteScenario)
    {
        TestLogin_Ok();

        _ = new LaunchesModel(PageFactory, Configuration, LogProvider, suiteScenario["LAUNCH"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "TOTAL", suiteScenario["TOTAL"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "PASSED", suiteScenario["PASSED"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "FAILED", suiteScenario["FAILED"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "SKIPPED", suiteScenario["SKIPPED"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "PRODUCT BUG", suiteScenario["PRODUCT BUG"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "AUTO BUG", suiteScenario["AUTO BUG"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "SYSTEM ISSUE", suiteScenario["SYSTEM ISSUE"].ToString()).
            ValidateCellValues(suiteScenario["SUITE NAME"].ToString(), "TO INVESTIGATE", suiteScenario["TO INVESTIGATE"].ToString());
    }
}