using SeleniumExtras.PageObjects;
using Test4Net.UI.POM.Elements;
using Test4Net.UI.POM.Page;
using Test4Net.UI.WebBrowser.Browser.Interfaces;

namespace ReportPortal_POM.Pages;

public class LoginPage : AbstractPage
{
    [FindsBy(How = How.CssSelector, Using = "[name='login']")]
    public HtmlElement UserNameInput { get; set; }

    [FindsBy(How = How.CssSelector, Using = "[name='password']")]
    public HtmlElement UserPasswordInput { get; set; }

    [FindsBy(How = How.XPath, Using = "//button[@type='submit' and contains(text(),'Login')]")]
    public HtmlElement LoginButton { get; set; }

    public LoginPage(IWebBrowser browser) : base(browser)
    { }
}