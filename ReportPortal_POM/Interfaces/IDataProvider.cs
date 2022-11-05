namespace ReportPortal_POM.Interfaces;

public interface IDataProvider
{
    /// <summary>
    /// Path to resources 
    /// </summary>
    string DataSourcePath { get; set; }

    /// <summary>
    /// Delivering data source format
    /// </summary>
    /// <returns></returns>
    public IEnumerable<object[]> GetData();
}