using ReportPortal_APIClient.Domain.Request;
using ReportPortal_APIClient.Domain.Response;

namespace ReportPortal_APIClient.Domain.Resources;

/// <summary>
/// interacts with dashboard api
/// </summary>
public interface IDashboardResource
{
    /// <summary>
    /// Create dashboard for specified project
    /// </summary>
    /// <param name="createDashboardRequest"></param>
    /// <returns></returns>
    Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest);

    /// <summary>
    /// Update dashboard for specified project
    /// </summary>
    /// <param name="dashboardId"></param>
    /// <param name="updateDashboardRequest"></param>
    /// <returns></returns>
    Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest);

    /// <summary>
    /// Delete dashboard for specified project
    /// </summary>
    /// <param name="dashboardId"></param>
    /// <returns></returns>
    Task DeleteAsync(int dashboardId);
}