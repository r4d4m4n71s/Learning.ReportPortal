using System.Text.Json.Serialization;
using ReportPortal_APIClient.Domain.Request;
using ReportPortal_APIClient.Domain.Response;

namespace ReportPortal_APIClient.Converters;

/// <inheritdoc />
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

[JsonSerializable(typeof(CreateDashboardRequest))]
[JsonSerializable(typeof(CreateDashboardResponse))]
[JsonSerializable(typeof(UpdateDashboardRequest))]
[JsonSerializable(typeof(UpdateDashboardResponse))]
public partial class ClientSourceGenerationContext : JsonSerializerContext
{
}