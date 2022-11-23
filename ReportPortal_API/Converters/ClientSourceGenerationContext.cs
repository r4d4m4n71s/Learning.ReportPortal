using System.Text.Json.Serialization;

namespace ReportPortal_APIClient.Converters;

/// <inheritdoc />
[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

[JsonSerializable(typeof(Abstractions.Request.CreateDashboardRequest))]
[JsonSerializable(typeof(Abstractions.Request.UpdateDashboardRequest))]
public partial class ClientSourceGenerationContext : JsonSerializerContext
{
}