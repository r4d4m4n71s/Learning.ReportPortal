using ReportPortal_POM.Models;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.Logging.Provider;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_xUnitTest.UnitTest;

public class UnitTest
{
    private readonly IPageFactory PageFactory;
    private readonly IConfiguration Configuration;
    private readonly ILogProvider LogProvider = new LogProvider();

    [Fact]
    [Trait("Category", "Unit")]
    public void TestGetUrlExtension_ok()
    {
        Configuration.GetUrl("DashboardPath").Should().
            BeEquivalentTo(new Uri(Path.Combine(Configuration["BaseUrl"], Configuration["DashboardPath"])));
    }

    [Fact]
    [Trait("Category", "Unit")]
    public void TestGetModelExtension_ok()
    {
        var fakeModel = new AuthModel(PageFactory, Configuration, LogProvider);
        fakeModel.GetModel<DashboardModel>().Should().NotBeNull();
    }
}