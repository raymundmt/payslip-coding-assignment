using PayslipCodingAssignment.Domain.Interfaces;
using Serilog;

namespace PayslipCodingAssignment.Infrastructure.Loggers;
public class SerilogLogger<T> : IAppLogger<T>
{
    public void LogInformation(string message)
    {
        Log.Information(message);
    }

    public void LogWarning(string message)
    {
        Log.Warning(message);
    }

    public void LogError(string message)
    {
        Log.Error(message);
    }
}
