using Microsoft.Extensions.Logging;

namespace AutoFixture.Customizations.LoggerFactoryCustomizations
{
    internal class LoggerFactoryCustomization : ICustomization
    {
        private readonly ILoggerFactory loggerFactory;

        public LoggerFactoryCustomization(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new LoggerSpecimenBuilder(loggerFactory));
        }
    }
}