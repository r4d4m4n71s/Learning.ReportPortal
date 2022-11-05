namespace ReportPortal_MSTest.Util;

internal static class Conventions
{
    /// <summary>
    /// Application environments
    /// </summary>
    public enum AppEnvironment
    {
        Dev,
        Qa,
        PreProd,
        Prod
    }

    /// <summary>
    /// Define keys to global variables
    /// </summary>
    public enum EnvironmentVariableName
    {
        AppEnv,
        BrowserProfile
    }
}