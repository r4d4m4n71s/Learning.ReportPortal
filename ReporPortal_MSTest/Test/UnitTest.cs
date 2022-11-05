using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportPortal_POM.Models;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.Logging.Provider;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_MSTest.Test;

[TestClass]
public class UnitTest : BaseTest
{
    [TestMethod]
    [TestCategory("Unit")]
    public void TestGetUrlExtension_ok()
    {
        Configuration.GetUrl("DashboardPath").Should().
            BeEquivalentTo(new Uri(Path.Combine(Configuration["BaseUrl"], Configuration["DashboardPath"])));
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void TestGetModelExtension_ok()
    {
        var fakeModel = new AuthModel(PageFactory, Configuration, LogProvider);
        fakeModel.GetModel<DashboardModel>().Should().NotBeNull();
    }
}