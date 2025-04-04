using System;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Lib.Cosmos.Tests.Fakes;

public sealed class LoggerFake : ILogger
{
    public StringBuilder Logs { get; } = new StringBuilder();

    public IDisposable BeginScope<TState>(TState state) where TState : notnull => throw new NotImplementedException();
    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) => Logs.AppendLine(formatter(state, exception));
}