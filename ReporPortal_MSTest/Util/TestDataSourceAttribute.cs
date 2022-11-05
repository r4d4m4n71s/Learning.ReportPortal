using System.Globalization;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportPortal_POM.Interfaces;

namespace ReportPortal_MSTest.Util;

[AttributeUsage(AttributeTargets.Method)]
public sealed class TestDataSourceAttribute : Attribute, ITestDataSource
{
    private readonly IDataProvider _dataProvider;

    /// <summary>
    /// Notation that consumes data and transforms to
    /// enumeration of objects using a data provider.  Finally converts it
    /// into scenarios
    /// </summary>
    /// <param name="dataSourcePath"></param>
    /// <param name="dataProviderType"></param>
    public TestDataSourceAttribute(string dataSourcePath, Type dataProviderType)
    {
        _dataProvider = (IDataProvider)Activator.CreateInstance(dataProviderType);
        _dataProvider!.DataSourcePath = dataSourcePath;
    }

    /// <summary>
    /// Retrieves the data from data source
    /// and delivers to main test control execution to split on scenarios
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <returns></returns>
    public IEnumerable<object[]> GetData(MethodInfo methodInfo) => 
        _dataProvider.GetData();

    /// <summary>
    /// Displays a pre-formatted name
    /// for executed scenario in the output.
    /// </summary>
    /// <param name="methodInfo"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public string GetDisplayName(MethodInfo methodInfo, object[] data)
    {
        if (data != null)
            return string.Format(CultureInfo.CurrentCulture, "{0} scenario ({1})", methodInfo.Name, data[0]);

        return null;
    }
}