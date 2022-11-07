using ReportPortal_POM.Models;
using ReportPortal_POM.Util;

namespace ReportPortal_SpecFlowTest.StepDefinitions;

[Binding]
public class LaunchStepDefinitions : BaseSteps
{
    [Given(@"User is authenticated")]
    public void GivenUserIsAuthenticated()
    {
        _ = new AuthModel(PageFactory, Configuration, LogProvider).
            PerformLogin(Configuration["UserName"], Configuration["UserPassword"])
            .GetModel<DashboardModel>().IsDashboardOpen();
        LogProvider.GetLogger<LaunchStepDefinitions>().Info("Login test ok!.");
    }

    [When(@"User goes to the launches board")]
    public void WhenUserGoesToTheBoard()
    {
        _ = new LaunchesModel(PageFactory, Configuration, LogProvider)
            .EnsureNavigationToTheBoard();
    }

    [Then(@"The launch matches the following columns: '([^']*)' '([^']*)' '([^']*)' '([^']*)'")]
    public void ThenTheLaunchMatchesTheFollowingColumns(int launchNumber,
        string expectedTotal, string expectedPassed, string expectedFailed)
    {
        new LaunchesModel(PageFactory, Configuration, LogProvider).
            ValidateCellValues(launchNumber, "TOTAL", expectedTotal).
            ValidateCellValues(launchNumber, "PASSED", expectedPassed).
            ValidateCellValues(launchNumber, "FAILED", expectedFailed);
    }
}