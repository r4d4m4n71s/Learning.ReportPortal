using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ReportPortal_xUnitTest.UnitTest.Fakes
{
    public class Driver_Fake : IWebDriver, IJavaScriptExecutor
    {
        #region Fields
        private string _url = "Fake Url";
        public string Url
        {
            get => navigationFake.Url;
            set => _url = value;
        }

        public string Title { get; set; } = "Fake Title";

        public string PageSource { get; set; } = "Fake Source";

        public string CurrentWindowHandle { get; set; } = "Fake Handle";

        public ReadOnlyCollection<string> WindowHandles => null;

        private Navigation navigationFake = new Navigation();
        #endregion

        #region Delegates
        public delegate void CloseDelegate();
        public delegate void DisposeDelegate();
        public delegate IWebElement FindElementDelegate(By by);
        public delegate ReadOnlyCollection<IWebElement> FindElementsDelegate(By by);
        public delegate Screenshot GetScreenshotDelegate();
        public delegate IOptions ManageDelegate();
        public delegate INavigation NavigateDelegate(INavigation fake);
        public delegate void QuitDelegate();
        public delegate ITargetLocator SwitchToDelegate();
        public delegate object ExecuteScriptDelegate(string script, params object[] args);
        public delegate object ExecuteAsyncScriptDelegate(string script, params object[] args);
        #endregion

        #region Defaults
        public CloseDelegate CloseFunction = () => { };
        public DisposeDelegate DisposeFunction = () => { };
        public FindElementDelegate FindElementFunction = b => null;
        public FindElementsDelegate FindElementsFunction = b => null;
        public GetScreenshotDelegate GetScreenshotFunction = () => new Screenshot("iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mNk+P+/HgAFhAJ/wlseKgAAAABJRU5ErkJggg==");
        public ManageDelegate ManageFunction = () => null;
        public NavigateDelegate NavigateFunction = fake => fake;
        public QuitDelegate QuitFunction = () => { };
        public SwitchToDelegate SwitchToFunction = () => null;
        public ExecuteScriptDelegate ExecuteScriptFunction = (s, a) => new object();
        public ExecuteAsyncScriptDelegate ExecuteAsyncScriptFunction = (s, a) => new object();
        #endregion

        #region Methods
        public void Close() => CloseFunction();
        public void Dispose() => DisposeFunction();
        public IWebElement FindElement(By by) => FindElementFunction(by);
        public ReadOnlyCollection<IWebElement> FindElements(By by) => FindElementsFunction(by);
        public Screenshot GetScreenshot() => GetScreenshotFunction();
        public IOptions Manage() => ManageFunction();
        public INavigation Navigate()
        {
            //Url = navigationFake.Url;
            return NavigateFunction(navigationFake);
        }

        public void Quit() => QuitFunction();
        public ITargetLocator SwitchTo() => SwitchToFunction();
        public object ExecuteScript(string script, params object[] args) => ExecuteScriptFunction(script, args);
        public object ExecuteScript(PinnedScript script, params object[] args) => ExecuteScriptFunction(script.Source, args);
        public object ExecuteAsyncScript(string script, params object[] args) => ExecuteAsyncScriptFunction(script, args);
        #endregion
    }

    public class Navigation : INavigation
    {
        public string Url;


        public void Back()
        {
         
        }

        public void Forward()
        {
         
        }

        public void GoToUrl(string url)
        {
            Url = url;
        }

        public void GoToUrl(Uri url)
        {
            Url = url.ToString();
        }

        public void Refresh()
        {
         
        }
    }
}
