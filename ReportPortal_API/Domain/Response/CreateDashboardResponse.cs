using System.Text.Json.Serialization;

namespace ReportPortal_APIClient.Domain.Response;

public class CreateDashboardResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}