using System.Drawing;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Test4Net.UI.POM.Elements;
using Test4Net.UI.POM.Elements.Interfaces;

namespace ReportPortal_POM.Elements;

public class WidgetElement : HtmlElement
{
    private const string SizePattern = "width: (\\d+)px; height: (\\d+)px;";
    private const string PositionPattern = "translate\\((\\d+)px, (\\d+)px\\);";
    private readonly HtmlElement _resizeControl;

    public WidgetElement()
    {}

    public WidgetElement(IWebElement wrappedElement)
    {
        WrappedElement = wrappedElement;
        _resizeControl = new HtmlElement
        {
            WrappedElement = FindElement(By.ClassName("react-resizable-handle-se"))
        };
    }

    /// <summary>
    /// Scrolls to widget
    /// </summary>
    public void ScrollTo()
    {
        /*var a = new Actions(((IWrapsDriver)WrappedElement).WrappedDriver);
        a.scScrollToElement(this);
        a.Build().Perform();*/
        ((IJavaScriptExecutor)((IWrapsDriver)WrappedElement).WrappedDriver).ExecuteScript("arguments[0].scrollIntoView(true);", this);
    }

    /// <summary>
    /// Get size from style css
    /// </summary>
    /// <returns></returns>
    public Point GetSize()
    {
        var match = Regex.Match(GetAttribute("style"), SizePattern);
        return new Point(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value));
    }

    /// <summary>
    /// Get position from style css
    /// </summary>
    /// <returns></returns>
    public Point GetPosition()
    {
        var match = Regex.Match(GetAttribute("style"), PositionPattern);
        return new Point(Convert.ToInt32(match.Groups[1].Value), Convert.ToInt32(match.Groups[2].Value));
    }

    /// <summary>
    /// Resizes widget (+/-) offset
    /// </summary>
    /// <param name="offset"></param>
    public void ResizeToOffSet(Point offset)
    {
        var a = new Actions(((IWrapsDriver)WrappedElement).WrappedDriver);
        //a.DragAndDropToOffset(_resizeControl, offset.X, offset.Y).Release();
        a.MoveToElement(_resizeControl);
        a.ClickAndHold().MoveByOffset(offset.X, offset.Y).Release();
        a.Build().Perform();
    }

    /// <summary>
    /// Move widget to x,y offset
    /// </summary>
    /// <param name="offset"></param>
    public void Move(Point offset)
    {
        var a = new Actions(((IWrapsDriver)WrappedElement).WrappedDriver);
        a.MoveToElement(this, offset.X, offset.Y);
        a.Build().Perform();
    }

    /// <summary>
    /// Drags the widget from one point and drops to position
    /// </summary>
    /// <param name="toPosition"></param>
    public void DragAndDropTo(IHtmlElement toPosition)
    {
        var a = new Actions(((IWrapsDriver)WrappedElement).WrappedDriver);
        a.DragAndDrop(this, toPosition);
        a.Build().Perform();
    }

    /// <summary>
    /// Drags the widget from one point and drops to offset position (x,y)
    /// </summary>
    /// <param name="offset"></param>
    public void DragAndDropTo(Point offset)
    {
        var a = new Actions(((IWrapsDriver)WrappedElement).WrappedDriver);
        a.DragAndDropToOffset(this, offset.X, offset.Y);
    }
}