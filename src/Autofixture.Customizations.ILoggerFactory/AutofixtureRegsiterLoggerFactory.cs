using AutoFixture.Customizations.LoggerFactoryCustomization;
using Microsoft.Extensions.Logging;

namespace AutoFixture
{
    public static class AutofixtureRegsiterLoggerFactory
    {
        public static void RegisterLoggerFactory(this IFixture fixture, ILoggerFactory loggerFactory)
        {
            fixture.Customize(new LoggerFactoryCustomization(loggerFactory));
        }
    }
}
