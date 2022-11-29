using FluentAssertions;
using ReportPortal_APIClient.Domain.Models;
using ReportPortal_APIClient.Domain.Request;

namespace ReportPortal_APITest.Test;

public class DashboardCrudTest : BaseTest
{
    private int _projectId = 27;

    [Fact]
    public async Task CreateTest()
    {
        var response = await Service.Dashboard.CreateAsync(
            new CreateDashboardRequest
            {
                Description = "This is a new dashboard created from api",
                Name = "Api dashboard",
                Share = true
            });

        // Check dashboard number is returned
        response.Id.Should().BeGreaterThan(0);
        _projectId = response.Id;
    }

    [Fact]
    public async Task UpdateTest()
    {
        var response = await Service.Dashboard.UpdateAsync(
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

        // Validate response message
        response.Message.Should().NotBeEmpty();
    }

    [Fact]
    public void DeleteTest()
    {
        var act = () =>
        {
            Service.Dashboard.DeleteAsync(22);
        };
        act.Should().NotThrow();
    }
}