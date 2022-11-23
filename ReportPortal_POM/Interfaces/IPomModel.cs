using Microsoft.Extensions.Configuration;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Interfaces
{
    public interface IPomModel
    {
        IPageFactory PageFactory { get; }
        IConfiguration Configuration { get; }
        ILogProvider LogProvider { get; }
    }
}
