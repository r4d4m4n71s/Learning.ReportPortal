using System.Text.Json.Serialization;

namespace ReportPortal_APIClient.Domain.Response;

public class UpdateDashboardResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }
}