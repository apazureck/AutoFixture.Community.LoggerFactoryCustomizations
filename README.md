# AutoFixture.Customizations.LoggerFactoryCustomization

Extension to easily inject the abstract ILoggerFactory to your device under test.

## What?

This extension to `AutoFixture` will create any logger from a test fixture without having to manually call `fixture.Register<ILogger<MyClass>>(loggerFactory.CreateLogger<MyClass>())`. Thus, reducing the code needed to push the logging output for example on the test output or using any compatible assertions for log messages, like the `Serilog` `InMemoryLogSink`.

## Why?

In my ASP.NET Core / .NET Core projects I always use the logging abstractions provided by Microsoft. I like being able to check the quality of my log messages in my unit tests, too, without writing dedicated tests for my logging. As it was always quite a pain in the connector to my office chair registering each logger individually I thought it would be nice to have a decent extension method registering my provided logging factory in my test at my test fixture.

## Example in XUnit2

> I used the package `Divergic.Logging.Xunit` and `Objectivity.AutoFixture.XUnit2.AutoMoq` for this.

In the test case, it is possible to register the loggerfactory created in your test. You need to register your `ILoggerFactory` at the `IFxiture` using the provided extension method. It should show up when you are using the `Autofixture` namespace and have this package installed.

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

This creates the following test output:

```
Information [0]: Hello World
```
