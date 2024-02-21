namespace GladsonEF.Domain.Configuration;

public class LoggerSettings
{
    public string AppName { get; set; } = "GladsonEF (Default)";
    public bool WriteToFile { get; set; } = false;
    public bool StructuredConsoleLogging { get; set; } = false;
    public string MinimumLogLevel { get; set; } = "Information";
}