using ReportPortal_APIClient.Domain;
using ReportPortal_APIClient.Domain.Resources;
using ReportPortal_APIClient.Resources;

namespace ReportPortal_APIClient.Service;

/// <inheritdoc cref="IClientService"/>
public class Service : IClientService, IDisposable
{
    private readonly HttpClient _httpClient;

    /// <summary>
    /// Constructor to initialize a new object of service.
    /// </summary>
    /// <param name="uri">Base URI for REST service.</param>
    /// <param name="projectName">A project to manage.</param>
    /// <param name="token">A token for user. Can be UID given from user's profile page.</param>
    /// <param name="httpClientFactory">Factory object to create an instance of <see cref="HttpClient"/>.</param>
    public Service(Uri uri, string projectName, string token, IHttpClientFactory httpClientFactory = null)
    {
        ProjectName = projectName;

        if (httpClientFactory == null)
        {
            httpClientFactory = new HttpClientFactory(uri, token);
        }

        _httpClient = httpClientFactory.Create();
        Dashboard = new ServiceDashboardResource(_httpClient, ProjectName);
    }

    /// <summary>
    /// Gets current project name to interact with.
    /// </summary>
    public string ProjectName { get; }

    /// <inheritdoc />
    public void Dispose()
    {
        _httpClient.Dispose();
    }

    public IDashboardResource Dashboard { get; }
}