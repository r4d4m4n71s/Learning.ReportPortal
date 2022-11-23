using ReportPortal_APIClient.Abstractions.Request;
using ReportPortal_APIClient.Abstractions.Response;

namespace ReportPortal_APIClient.Abstractions.Resources;

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

    /// <inheritdoc cref="CreateAsync(CreateDashboardRequest)"/>
    /// <param name="createDashboardRequest"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest, CancellationToken cancellationToken);

    /// <summary>
    /// Update dashboard for specified project
    /// </summary>
    /// <param name="dashboardId"></param>
    /// <param name="updateDashboardRequest"></param>
    /// <returns></returns>
    Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest);

    /// <inheritdoc cref="CreateAsync(CreateDashboardRequest)"/>
    /// <param name="dashboardId"></param>
    /// <param name="updateDashboardRequest"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest, CancellationToken cancellationToken);

    /// <summary>
    /// Delete dashboard for specified project
    /// </summary>
    /// <param name="dashboardId"></param>
    /// <returns></returns>
    Task DeleteAsync(int dashboardId);

    /// <inheritdoc cref="CreateAsync(CreateDashboardRequest)"/>
    /// <param name="dashboardId"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteAsync(int dashboardId, CancellationToken cancellationToken);
}