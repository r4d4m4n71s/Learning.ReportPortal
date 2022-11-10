using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Interfaces;
using ReportPortal_POM.Pages;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;
using Test4Net.Util.Thread;

namespace ReportPortal_POM.Models;

public class DashboardModel : IPomModel
{
    public IPageFactory PageFactory { get; }
    public IConfiguration Configuration { get; }
    public ILogProvider LogProvider { get; }

    public DashboardModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider)
    {
        PageFactory = pageFactory;
        Configuration = configuration;
        LogProvider = logProvider;
    }

    /// <summary>
    /// Navigate to dashboard page
    /// </summary>
    public void NavigateTo()
    {
        var page = PageFactory.GetPage<DashboardPage>();
        page.Navigate().GoToUrl(Configuration.GetUrl("DashboardPath"));
    }

    /// <summary>
    /// Returns true if page header is displayed
    /// </summary>
    /// <returns></returns>
    public bool IsPageHeaderDisplayed() =>
        PageFactory.GetPage<DashboardPage>().Header.Displayed;
    
    /// <summary>
    /// Returns page header title
    /// </summary>
    /// <returns></returns>
    public string GetPageHeaderText() =>
        PageFactory.GetPage<DashboardPage>().Header.Text;
}