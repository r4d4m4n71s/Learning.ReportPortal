using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Interfaces;
using ReportPortal_POM.Pages;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

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

    public IPomModel IsDashboardOpen()
    {
        var page = PageFactory.GetPage<DashboardPage>();
        page.Navigate().GoToUrl(Configuration.GetUrl("DashboardPath"));

        // Validate at least page tittle is displayed
        page.Header.Displayed.Should().BeTrue();
        LogProvider.GetLogger<DashboardModel>().Info("Dashboard is open");
        return this;
    }
}