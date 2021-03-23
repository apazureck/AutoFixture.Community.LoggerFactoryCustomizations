using AutoFixture.Customizations.LoggerFactoryCustomizations;
using Microsoft.Extensions.Logging;

namespace AutoFixture
{
    public static class AutofixtureRegsiterLoggerFactoryExtension
    {
        public static void RegisterLoggerFactory(this IFixture fixture, ILoggerFactory loggerFactory)
        {
            fixture.Customize(new LoggerFactoryCustomization(loggerFactory));
        }
    }
}
