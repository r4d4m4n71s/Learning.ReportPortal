using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Models;

/// <summary>
/// Use model for single launch
/// </summary>
public class LaunchModel : LaunchesModel
{
    /// <summary>
    /// Build under launchNumber criteria
    /// </summary>
    /// <param name="pageFactory"></param>
    /// <param name="configuration"></param>
    /// <param name="logProvider"></param>
    /// <param name="launchNumber"></param>
    public LaunchModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider, 
        int launchNumber) :
        base(pageFactory, configuration, logProvider)
    {
        GridUrl = new Uri(Configuration.GetUrl("LaunchesPath") + $"/all/{launchNumber}");
    }
}