using Microsoft.Extensions.Configuration;
using Test4Net.UITest.Models;

namespace ReportPortal_SpecFlowTest.StepDefinitions;

public abstract class BaseSteps : AbstractUiTest
{ 
    /// <summary>
    /// Path to folder with configurations
    /// </summary>
    protected static readonly string SetupPath = Path.Join(Directory.GetCurrentDirectory(), "/Configuration");

    /// <summary>
    /// Dic of multiple driver settings
    /// </summary>
    protected static string DriverSettings { get; } = File.ReadAllText(Path.Combine(SetupPath, "driver.settings.json"));

    /// <summary>
    /// Configurations from json files
    /// </summary>
    protected readonly IConfiguration Configuration;

    protected BaseSteps()
    {
        InitFactories(Environment.GetEnvironmentVariable(
            Conventions.EnvironmentVariableName.BROWSERPROFILE.ToString()), DriverSettings);

        Configuration = new ConfigurationBuilder()
            .SetBasePath(SetupPath)
            .AddEnvironmentVariables()
            .AddJsonFile($"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.APPENVIRONMENT.ToString())}.settings.json",
                optional: true, reloadOnChange: true).Build();

        LogProvider = ConfigureLogger(Configuration.GetSection("Logging"));
    }
}