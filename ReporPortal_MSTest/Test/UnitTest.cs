using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportPortal_MSTest.Util;
using ReportPortal_POM.Models;
using ReportPortal_POM.Util;

namespace ReportPortal_MSTest.Test;

[TestClass]
public class UnitTest : BaseTest
{
    [TestMethod]
    [TestCategory("unit")]
    public void TestGetUrlExtension_ok()
    {
        Configuration.GetUrl("DashboardPath").Should().
            BeEquivalentTo(new Uri(Path.Combine(Configuration["BaseUrl"], Configuration["DashboardPath"])));
    }

    [TestMethod]
    [TestCategory("unit")]
    public void TestGetModelExtension_ok()
    {
        var fakeModel = new AuthModel(PageFactory, Configuration, LogProvider);
        fakeModel.GetModel<DashboardModel>().Should().NotBeNull();
    }

    [TestMethod]
    [TestCategory("unit")]
    [TestDataSource("TestData/LaunchXSuites.csv", typeof(CsvDataProvider))]
    public void CheckDataSourceAttribute_Ok(IDictionary<string, object> suiteScenario)
    {
        suiteScenario.Should().NotBeNull();
    }
}