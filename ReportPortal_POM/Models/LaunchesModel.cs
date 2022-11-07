using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Pages;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Models;

/// <summary>
/// Use model for root launches
/// </summary>
public class LaunchesModel : AbstractModel
{
    protected Uri GridUrl;
    protected readonly LaunchesPage LaunchesPage;
    protected string NavigationPath = "/all";

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="pageFactory"></param>
    /// <param name="configuration"></param>
    /// <param name="logProvider"></param>
    public LaunchesModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider) :
        this(pageFactory, configuration, logProvider, string.Empty)
    {}

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="pageFactory"></param>
    /// <param name="configuration"></param>
    /// <param name="logProvider"></param>
    /// <param name="navigationPath"></param>
    public LaunchesModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider,
        string navigationPath): base(pageFactory, configuration, logProvider)
    {
        if (!string.IsNullOrEmpty(navigationPath))
            NavigationPath = NavigationPath + "/" + navigationPath;

        LaunchesPage = PageFactory.GetPage<LaunchesPage>();
        GridUrl = new Uri(Configuration.GetUrl("LaunchesPath") + NavigationPath);
    }

    /// <summary>
    /// Validate a grid cell using the data-id attribute from html
    /// and the first coincidence with the columnName
    /// </summary>
    /// <param name="dataIdAttrValue"></param>
    /// <param name="columnName"></param>
    /// <param name="expectedValue"></param>
    /// <returns></returns>
    public LaunchesModel ValidateCellValues(int dataIdAttrValue, string columnName, string expectedValue)
    {
        var page = PageFactory.GetPage<LaunchesPage>();
        EnsureNavigationToTheBoard();

        var total = page.GetCellValue(dataIdAttrValue, columnName);
        total.Should().BeEquivalentTo(expectedValue, $"{columnName} doesn't match for data-id: {dataIdAttrValue}");
        return this;
    }

    /// <summary>
    /// Validate a grid cell using the first row match with the rowName
    /// and the first column match with the column name
    /// </summary>
    /// <param name="rowName"></param>
    /// <param name="columnName"></param>
    /// <param name="expectedValue"></param>
    /// <returns></returns>
    public LaunchesModel ValidateCellValues(string rowName, string columnName, string expectedValue)
    {
        var page = PageFactory.GetPage<LaunchesPage>();
        EnsureNavigationToTheBoard();

        var total = page.GetCellValue(rowName, columnName);
        total.Should().BeEquivalentTo(expectedValue, $"{columnName} doesn't match for row with name: {rowName}");
        return this;
    }

    /// <summary>
    /// If the launches board is not the current url
    /// navigates to it and validates was successfully.
    /// </summary>
    /// <returns></returns>
    public LaunchesModel EnsureNavigationToTheBoard()
    {
        var page = PageFactory.GetPage<LaunchesPage>();

        if (!page.Browser.Driver.Url.Equals(GridUrl.ToString()))
            page.GoToUrl(GridUrl);

        page.Browser.Driver.Url.Should().BeEquivalentTo(GridUrl.ToString());
        return this;
    }
}