﻿using System.Collections;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReportPortal_MSTest.Util;
using Test4Net.UITest.Models;

namespace ReportPortal_MSTest.Test;

[TestClass]
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
    
    protected BaseTest() 
    {
        foreach (DictionaryEntry envVar in Environment.GetEnvironmentVariables())
        {
            Console.WriteLine($" var {envVar.Key} : {envVar.Value}");   
        }

        Console.WriteLine($"User {Conventions.EnvironmentVariableName.BrowserProfile.ToString()}: " +
                          $"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.BrowserProfile.ToString())}");


        Console.WriteLine($"User {Conventions.EnvironmentVariableName.BrowserProfile.ToString()}: "+
            $"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.BrowserProfile.ToString(), EnvironmentVariableTarget.User)}");

        Console.WriteLine($"Process {Conventions.EnvironmentVariableName.BrowserProfile.ToString()}: " +
                          $"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.BrowserProfile.ToString(), EnvironmentVariableTarget.Process)}");

        Console.WriteLine($"Machine {Conventions.EnvironmentVariableName.BrowserProfile.ToString()}: " +
                          $"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.BrowserProfile.ToString(), EnvironmentVariableTarget.Machine)}");


        InitFactories(Environment.GetEnvironmentVariable(
            Conventions.EnvironmentVariableName.BrowserProfile.ToString(), EnvironmentVariableTarget.User), DriverSettings);

        Configuration = new ConfigurationBuilder()
            .SetBasePath(SetupPath)
            .AddEnvironmentVariables()
            .AddJsonFile($"{Environment.GetEnvironmentVariable(Conventions.EnvironmentVariableName.AppEnv.ToString())}.settings.json",
                optional: true, reloadOnChange: true).Build();

        LogProvider = ConfigureLogger(Configuration.GetSection("Logging"));
    }
}