using System.Drawing;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ReportPortal_POM.Interfaces;
using ReportPortal_POM.Pages;
using ReportPortal_POM.Util;
using Test4Net.Logging.Interfaces;
using Test4Net.UI.POM.Page.Interfaces;

namespace ReportPortal_POM.Models;

public class DashboardModel : IPomModel
{
    public IPageFactory PageFactory { get; }
    public IConfiguration Configuration { get; }
    public ILogProvider LogProvider { get; }

    public DashboardModel(IPageFactory pageFactory, IConfiguration configuration, ILogProvider logProvider)
    {
        PageFactory = pageFactory;
        Configuration = configuration;
        LogProvider = logProvider;
    }

    public DashboardModel IsDashboardOpen()
    {
        GoToDashBoard();
        PageFactory.GetPage<DashboardPage>().Header.Displayed.Should().BeTrue();
        LogProvider.GetLogger<DashboardModel>().Info("Dashboard is open");
        return this;
    }

    public DashboardModel GoToDashBoard(string id = null)
    {
        var page = PageFactory.GetPage<DashboardPage>();
        page.Navigate().GoToUrl(Configuration.GetUrl("DashboardPath") + (string.IsNullOrEmpty(id) ? "" : $"/{id}"));
        return this;
    }
    public void MoveWidget(string name, Point offset)
    {
        var widget = PageFactory.GetPage<DashboardPage>().GetWidget(name);
        widget.DragAndDropTo(offset);
    }

    public void ResizeWidget(string name, Point offset)
    {
        var widget = PageFactory.GetPage<DashboardPage>().GetWidget(name);
        widget.ResizeToOffSet(offset);
    }

    public Point GetWidgetPosition(string name)
    {
        var widget = PageFactory.GetPage<DashboardPage>().GetWidget(name);
        return widget.GetPosition();
    }

    public Point GetWidgetSize(string name)
    {
        var widget = PageFactory.GetPage<DashboardPage>().GetWidget(name);
        return widget.GetSize();
    }
}