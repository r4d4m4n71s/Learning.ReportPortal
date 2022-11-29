using Microsoft.Extensions.Configuration;
using ReportPortal_APIClient.Service;

namespace ReportPortal_APITest.Test;

public abstract class BaseTest
{
    /// <summary>
    /// Configurations from json files
    /// </summary>
    protected readonly IConfiguration Configuration;

    protected readonly Service Service;

    public BaseTest() 
    {
        Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "/Configuration"))
                .AddEnvironmentVariables()
                .AddJsonFile($"{Environment.GetEnvironmentVariable("APPENVIRONMENT")}.settings.json",
                    optional: true, reloadOnChange: true).Build();

        Service = new Service(
            new Uri(Configuration["BaseUrl"] + Configuration["ApiPath"]), 
            Configuration["ProjectName"],
            Configuration["Uuid"]);
    }
}