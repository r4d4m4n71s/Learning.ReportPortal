using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using ReportPortal_POM.Interfaces;

namespace ReportPortal_POM.Util;

/// <summary>
/// DataProvider for retrieving data from csv files
/// </summary>
public class CsvDataProvider : IDataProvider
{
    /// <summary>
    /// Target Csv file path
    /// </summary>
    public string DataSourcePath { get; set; }

    /// <summary>
    /// Retrieves data from the Csv resource
    /// </summary>
    /// <returns>Csv data</returns>
    public IEnumerable<object[]> GetData() => ReadFile(DataSourcePath).ToEnumObj();

    /// <summary>
    /// Reads information from a Csv file
    /// </summary>
    /// <param name="filePath">target file path</param>
    /// <returns>Csv file data</returns>
    private IEnumerable<IDictionary<string, object>> ReadFile(string filePath)
    {
        var result = new List<Dictionary<string, object>>();

        // Open the path with csv reader
        using (var reader = new StreamReader(filePath))
        using (var csvReader = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
               {
                   HasHeaderRecord = true, // header is assumed by default
                   HeaderValidated = null,
                   MissingFieldFound = null
               }))
        {
            // Read each line into a dictionary
            while (csvReader.Read())
            {
                var row = csvReader.GetRecord<dynamic>();
                // Clone the dynamic object into a dictionary
                var rowDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(
                    JsonConvert.SerializeObject(row));
                result.Add(rowDictionary);
            }
        }
        return result;
    }
}