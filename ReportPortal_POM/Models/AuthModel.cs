using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Interfaces;
using ReportPortal_POM.Pages;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Models;

public class AuthModel : IPomModel
{
    public IPageFactory PageFactory { get; }
    public IConfiguration Configuration { get; }
    public ILogProvider LogProvider { get; }

    public AuthModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider)
    {
        PageFactory = pageFactory;
        Configuration = configuration;
        LogProvider = logProvider;
    }

    public IPomModel PerformLogin(string userName, string password)
    {
        var page = PageFactory.GetPage<LoginPage>();
        page.Navigate().GoToUrl(Configuration.GetUrl("LoginPath"));
        page.UserNameInput.SendKeys(userName);
        page.UserPasswordInput.SendKeys(password);
        page.LoginButton.Click();
        return this;
    }
    
}