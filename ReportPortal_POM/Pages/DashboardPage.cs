using SeleniumExtras.PageObjects;
using Test4Net.UI.POM.Elements;
using Test4Net.UI.POM.Page;
using Test4Net.UI.WebBrowser.Browser.Interfaces;

namespace ReportPortal_POM.Pages;

public class DashboardPage : AbstractPage
{
    [FindsBy(How = How.CssSelector, Using = "span[title = 'All Dashboards']")]
    public HtmlElement Header { get; set; }

    public DashboardPage(IWebBrowser browser) : base(browser)
    { }
}