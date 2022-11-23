using ReportPortal_APIClient.Service;

namespace ReportPortal_APITest.Test;

public abstract class BaseTest
{
    protected static readonly string ProjectName = "AUTOMATIONTRAINING";
    protected static readonly string Uuid = "34540b5d-0f02-4150-a7be-2511fff832c5";
    protected readonly Service Service = new Service(new Uri("http://localhost:8080/api/v1"), ProjectName, Uuid);
}