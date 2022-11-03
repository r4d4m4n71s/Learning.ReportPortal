using ReportPortal_POM.Models;
using ReportPortal_xUnitTest.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Interfaces;
using ReportPortal_POM.Util;
using ReportPortal_xUnitTest.UnitTest.Fakes;
using Test4Net.Logging.Interfaces;
using Test4Net.Logging.Provider;
using Test4Net.UI.POM.Page;
using Test4Net.UI.POM.Page.Interfaces;
using Test4Net.UI.WebBrowser.Browser;

namespace ReportPortal_xUnitTest.UnitTest;

public class UnitTest
{
    private readonly IPageFactory PageFactory;
    private readonly IConfiguration Configuration;
    private readonly ILogProvider LogProvider = new LogProvider();

    public UnitTest()
    {
        PageFactory = new PageFactory(new WebBrowser("fakeConfId", new Driver_Fake()));

        Configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("Configuration/Dev.settings.json", optional: true, reloadOnChange: true).Build();
    }

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