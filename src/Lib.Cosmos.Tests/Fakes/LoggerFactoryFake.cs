using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class LoggerFactoryFake : ILoggerFactory
{
    public ILogger CreateLogger(string categoryName) => new LoggerFake();

    public void AddProvider(ILoggerProvider provider)
    {
        // No-op for testing
    }

    public void Dispose()
    {
        // No-op for testing
    }
}