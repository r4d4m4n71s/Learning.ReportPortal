using Microsoft.Extensions.Configuration;
using Test4Net.UITest.Models;
using ExecutionContext = Test4Net.UITest.Models.ExecutionContext;

namespace ReportPortal_xUnitTest.Test;

public abstract class BaseTest : AbstractUiTest
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


    protected BaseTest() : base(
        new ExecutionContext(
        Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.BrowserProfile.ToString(),
            EnvironmentVariableTarget.User), DriverSettings))
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(SetupPath)
            .AddEnvironmentVariables()
            .AddJsonFile($"{Environment.GetEnvironmentVariable(nameof(Conventions.AppEnvironment), EnvironmentVariableTarget.User)}.settings.json",
                optional: true, reloadOnChange: true).Build();

        LogProvider = ConfigureLogger(Configuration.GetSection("Logging"));
    }
    
}