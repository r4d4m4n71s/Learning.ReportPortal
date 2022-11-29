using ReportPortal_APIClient.Domain.Request;
using ReportPortal_APIClient.Domain.Response;

namespace ReportPortal_APIClient.Domain.Resources;

/// <summary>
/// interacts with dashboard api
/// </summary>
public interface IWidgetResource
{
    /// <summary>
    /// Create widget 
    /// </summary>
    /// <param name="createDashboardRequest"></param>
    /// <returns></returns>
    Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest);

    /// <inheritdoc cref="CreateAsync(CreateDashboardRequest)"/>
    /// <param name="createDashboardRequest"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest, CancellationToken cancellationToken);

    /// <summary>
    /// Update widget 
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
    /// Delete widget 
    /// </summary>
    /// <param name="dashboardId"></param>
    /// <returns></returns>
    Task DeleteAsync(int dashboardId);

    /// <inheritdoc cref="CreateAsync(CreateDashboardRequest)"/>
    /// <param name="dashboardId"></param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task DeleteAsync(int dashboardId, CancellationToken cancellationToken);
}