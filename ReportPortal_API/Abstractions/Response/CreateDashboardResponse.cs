using System.Text.Json.Serialization;

namespace ReportPortal_APIClient.Abstractions.Response;

public class CreateDashboardResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}