using ReportPortal_APIClient.Domain.Resources;

namespace ReportPortal_APIClient.Domain
{
    /// <summary>
    /// Interface to interact with common Report Portal services. Provides possibility to manage almost of service's endpoints.
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Dashboard resource handler
        /// </summary>
        IDashboardResource Dashboard { get; }
    }
}