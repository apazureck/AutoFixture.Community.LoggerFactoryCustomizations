# AutoFixture.Customizations.LoggerFactoryCustomization

Extension to easily inject the abstract ILoggerFactory to your device under test.

Example in XUnit2:

```csharp
public class DemoTests
    {
        private readonly ILoggerFactory loggerFactory;

        public DemoTests(ITestOutputHelper toh)
        {
            loggerFactory = LogFactory.Create(toh);
        }
        [Theory, AutoMockData]
        public void HowToUseTest(IFixture fixture)
        {
            fixture.RegisterLoggerFactory(loggerFactory);
            var cut = fixture.Create<CutWithTestLogger>();

            cut.PrintLog();
        }
    }

    public class CutWithTestLogger
    {
        private readonly ILogger<CutWithTestLogger> logger;

        public CutWithTestLogger(ILogger<CutWithTestLogger> logger)
        {
            this.logger = logger;
        }

        public void PrintLog()
        {
            logger.LogInformation("Hello World");
        }
    }
```
