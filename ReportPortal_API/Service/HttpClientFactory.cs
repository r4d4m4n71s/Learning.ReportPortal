using System.Net.Http.Headers;
using ReportPortal_APIClient.Abstractions;
using ReportPortal_APIClient.Extensions;

namespace ReportPortal_APIClient.Service;

public class HttpClientFactory : IHttpClientFactory
{
    private readonly Uri _baseUri;
    private readonly string _token;

    public HttpClientFactory(Uri baseUri, string token)
    {
        _baseUri = baseUri;
        _token = token;
    }

    public HttpClient Create()
    {
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = (_, cert, chain, errors) => true;

        var httpClient = new HttpClient(httpClientHandler);

        httpClient.BaseAddress = _baseUri.Normalize();

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
        httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Reporter");

        return httpClient;
    }
}
