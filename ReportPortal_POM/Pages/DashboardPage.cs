using OpenQA.Selenium;
using ReportPortal_POM.Elements;
using ReportPortal_POM.Util;
using SeleniumExtras.PageObjects;
using Test4Net.UI.POM.Elements;
using Test4Net.UI.POM.Page;
using Test4Net.UI.WebBrowser.Browser.Interfaces;

namespace ReportPortal_POM.Pages;

public class DashboardPage : AbstractPage
{
    private const string WidgetByNameXpath =
        "//div[contains(@class,'widgetHeader__widget-name-block') and text() = '{0}']/ancestor::div[contains(@class,'widgetsGrid__widget-view')]";

    [FindsBy(How = How.CssSelector, Using = "span[title = 'All Dashboards']")]
    public HtmlElement Header { get; set; }

    public DashboardPage(IWebBrowser browser) : base(browser)
    { }

    public WidgetElement GetWidget(string name)
    {
        var widget = Browser.Driver.WaitForElement<WidgetElement>(By.XPath(string.Format(WidgetByNameXpath, name)));
        widget.ScrollTo();
        return widget;
    }
}