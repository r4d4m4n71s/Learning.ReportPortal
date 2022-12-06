using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using ReportPortal_POM.Interfaces;
using Test4Net.UI.POM.Elements;

namespace ReportPortal_POM.Util;

public static class GeneralExtensions
{
    /// <summary>
    /// Resolve a path to url using a defined base path
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="keyPath"></param>
    /// <param name="baseUrl"></param>
    /// <returns></returns>
    public static Uri GetUrl(this IConfiguration configuration, string keyPath, Uri baseUrl = null) =>
        baseUrl != null ? new Uri(baseUrl, configuration[keyPath]) : 
            new Uri(Path.Combine(configuration["BaseUrl"], configuration[keyPath]));

    /// <summary>
    /// Creates a new model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="model"></param>
    /// <returns></returns>
    public static T GetModel<T>(this IPomModel model) where T : IPomModel =>
        (T)Activator.CreateInstance(typeof(T), model.PageFactory, model.Configuration, model.LogProvider);

    /// <summary>
    /// Converts list dictionary in a list of object array with the dictionary into the array
    /// </summary>
    /// <param name="listDic"></param>
    /// <returns></returns>
    public static IEnumerable<object[]> ToEnumObj(this IEnumerable<IDictionary<string, object>> listDic) => 
        listDic.Select(dic => new object[] { dic }).ToList();

    /// <summary>
    /// Awaits for element instance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="driver"></param>
    /// <param name="by"></param>
    /// <param name="secondsTimeOut"></param>
    /// <param name="milSecondsPollInterval"></param>
    /// <returns></returns>
    public static T WaitForElement<T>(this IWebDriver driver, By by, 
        int secondsTimeOut = 5, int milSecondsPollInterval = 250) where T : HtmlElement, new()
    {
        var fluentWait = new DefaultWait<IWebDriver>(driver)
        {
            Timeout = TimeSpan.FromSeconds(secondsTimeOut),
            PollingInterval = TimeSpan.FromMilliseconds(milSecondsPollInterval)
        };
        /* Ignore the exception - NoSuchElementException that indicates that the element is not present */
        fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        fluentWait.Message = "Element to be searched not found";

        return (T)Activator.CreateInstance(typeof(T), fluentWait.Until(x => x.FindElement(by)));
    }
}