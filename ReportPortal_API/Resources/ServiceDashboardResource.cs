using ReportPortal_APIClient.Abstractions.Request;
using ReportPortal_APIClient.Abstractions.Resources;
using ReportPortal_APIClient.Abstractions.Response;

namespace ReportPortal_APIClient.Resources;

public class ServiceDashboardResource : ServiceBaseResource, IDashboardResource
{
    public ServiceDashboardResource(HttpClient httpClient, string projectName) : base(httpClient, projectName)
    {
    }

    public Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest) =>
        CreateAsync(createDashboardRequest, CancellationToken.None);

    public async Task<CreateDashboardResponse> CreateAsync(CreateDashboardRequest createDashboardRequest,
        CancellationToken cancellationToken) =>
        await PostAsJsonAsync<CreateDashboardResponse, CreateDashboardRequest>(
            $"{ProjectName}/dashboard", createDashboardRequest, cancellationToken).ConfigureAwait(false);

    public async Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest) => 
        await UpdateAsync(dashboardId, updateDashboardRequest, CancellationToken.None);

    public async Task<UpdateDashboardResponse> UpdateAsync(int dashboardId, UpdateDashboardRequest updateDashboardRequest,
        CancellationToken cancellationToken) =>
        await PutAsJsonAsync<UpdateDashboardResponse, UpdateDashboardRequest>(
            $"{ProjectName}/dashboard/{dashboardId}", updateDashboardRequest, cancellationToken).ConfigureAwait(false);

    public async Task DeleteAsync(int dashboardId) => 
        await DeleteAsync(dashboardId, CancellationToken.None);

    public async Task DeleteAsync(int dashboardId, CancellationToken cancellationToken) =>
        await DeleteAsJsonAsync<string>(
            $"{ProjectName}/dashboard/{dashboardId}", cancellationToken).ConfigureAwait(false);
}