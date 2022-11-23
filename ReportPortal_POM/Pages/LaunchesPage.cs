using OpenQA.Selenium;
using Test4Net.UI.POM.Page;
using Test4Net.UI.WebBrowser.Browser.Interfaces;

namespace ReportPortal_POM.Pages;

public class LaunchesPage : AbstractPage
{
    /// <summary>
    /// Xpath to grid column names
    /// </summary>
    private const string ColumnNamesXpath = "//span[contains(@class,'headerCell__title-full')]";

    /// <summary>
    /// Xpath to the div that represents a launch (row)
    /// </summary>
    private const string RowsByLaunchXpath =
        "//div[contains(@class,'gridRow__grid-row-wrapper') and @data-id='{0}']";

    /// <summary>
    /// Xpath to the row with the data-id where contains a specific text 
    /// </summary>
    private const string RowsByNameXpath =
        "//div[contains(@class,'tooltip__tooltip')]//span[text()='{0}']" +
        "/ancestor::div[contains(@class,'gridRow__grid-row-wrapper')]";

    /// <summary>
    /// Complements with launchXpath or launchXSuiteXpath to get the cells as list{div} 
    /// </summary>
    private const string GridCellsXpath = "{0}//div[contains(@class,'gridCell')]";

    public LaunchesPage(IWebBrowser browser) : base(browser)
    {
    }

    /// <summary>
    /// Returns first cell match value given:
    /// </summary>
    /// <param name="dataId">Unique key id</param>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public string GetCellValue(int dataId, string columnName)
    {
        // build xpath
        var xpath = string.Format(GridCellsXpath, string.Format(RowsByLaunchXpath, dataId));

        // Get the cells that meet the launch number
        var cellElements = Browser.Driver.FindElements(By.XPath(xpath));

        // Look up cell index according to the columnName
        var columnIndex = GetColumnIndex(columnName);
        return cellElements[columnIndex].Text;
    }

    /// <summary>
    /// Returns first cell match value given:
    /// </summary>
    /// <param name="rowName">looking up the row using column with the header:NAME</param>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public string GetCellValue(string rowName, string columnName)
    {
        // Build xpath
        var xpath = string.Format(RowsByNameXpath, rowName);

        var cellElements = Browser.Driver.FindElements(By.XPath(xpath));
        var dataId = cellElements.FirstOrDefault()!.GetAttribute("data-id");
        return GetCellValue(Convert.ToInt32(dataId), columnName);
    }

    /// <summary>
    /// Return the column index of the first column name occurrence
    /// </summary>
    /// <param name="columnName"></param>
    /// <returns>Column index</returns>
    private int GetColumnIndex(string columnName)
    {
        var headerElements = Browser.Driver.FindElements(By.XPath(ColumnNamesXpath));
        return headerElements.IndexOf(
            headerElements.FirstOrDefault(c => c.Text.Equals(columnName, StringComparison.OrdinalIgnoreCase)));
    }
}