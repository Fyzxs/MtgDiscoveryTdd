using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class LoggerFactoryTestHelper : ILoggerFactory
{
    private readonly ILogger _factoryLogger;

    public LoggerFactoryTestHelper(ILogger factoryLogger)
    {
        _factoryLogger = factoryLogger;
    }

    public ILogger CreateLogger(string categoryName)
    {
        if (categoryName.Contains("CosmosClientAdapterFactory"))
        {
            return _factoryLogger;
        }
        return new LoggerFake();
    }

    public void AddProvider(ILoggerProvider provider)
    {
        // No-op for testing
    }

    public void Dispose()
    {
        // No-op for testing
    }
}