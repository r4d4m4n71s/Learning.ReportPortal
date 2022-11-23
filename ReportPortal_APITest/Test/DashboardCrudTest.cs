using ReportPortal_APIClient.Abstractions.Models;
using ReportPortal_APIClient.Abstractions.Request;

namespace ReportPortal_APITest.Test;

public class DashboardCrudTest : BaseTest
{
    private int _projectId = 22;

    [Fact]
    public void CreateTest()
    {
        var response = Service.Dashboard.CreateAsync(
            new CreateDashboardRequest
            {
                Description = "This is a new dashboard created from api",
                Name = "Api dashboard",
                Share = true
            });

        _projectId = response.Id;
    }

    [Fact]
    public void UpdateTest()
    {
        Service.Dashboard.UpdateAsync(
            _projectId,
            new UpdateDashboardRequest
            {
                Description = $"Updating dashboard for project {_projectId} from api {new DateTime()}",
                Name = "Api dashboard",
                Share = false,
                UpdateWidgets = new List<WidgetModel>
                {
                    new()
                    {
                        Share = true,
                        WidgetId = 3,
                        WidgetName = "Test widget",
                        WidgetType = "any"
                    }
                }
            });
    }

    [Fact]
    public void DeleteTest()
    {
        Service.Dashboard.DeleteAsync(22);
    }
}