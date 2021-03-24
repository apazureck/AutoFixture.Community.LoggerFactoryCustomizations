using AutoFixture.Customizations.LoggerFactory;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Objectivity.AutoFixture.XUnit2.AutoMoq.Attributes;
using System.Reflection;
using Xunit;

namespace AutoFixture.Customizations.LoggerFactory.Tests
{
    public class LoggerSpecimenBuilderTests
    {
        [Theory, AutoMockData]
        public void CreatingAnyObject_Should_BeIgnored(IFixture fixture, ISpecimenContext context)
        {
            // Arrange

            var cut = CreateCut(fixture);

            // Act

            var createdObject = cut.Create(new object(), context);

            // Assert
            createdObject.Should().BeOfType<NoSpecimen>();
        }

        [Theory, AutoMockData]
        public void RequestingTypedLogger_Should_CreateLogger(
            IFixture fixture,
            ISpecimenContext context,
            Mock<ParameterInfo> piMock)
        {
            // Arrange

            var cut = CreateCut(fixture);
            piMock.Setup(pi => pi.ParameterType).Returns(typeof(ILogger<LoggerSpecimenBuilderTests>));

            // Act

            var createdObject = cut.Create(piMock.Object, context);

            // Assert
            createdObject.Should().BeAssignableTo<ILogger<LoggerSpecimenBuilderTests>>();
        }

        [Theory, AutoMockData]
        public void RequestingLoggerFactory_Should_ReturnLoggerFactory(
            IFixture fixture,
            ISpecimenContext context,
            Mock<ParameterInfo> piMock)
        {
            // Arrange

            var cut = CreateCut(fixture);
            piMock.Setup(pi => pi.ParameterType).Returns(typeof(ILoggerFactory));

            // Act

            var createdObject = cut.Create(piMock.Object, context);

            // Assert
            createdObject.Should().BeAssignableTo<ILoggerFactory>();
        }

        private LoggerSpecimenBuilder CreateCut(IFixture fixture)
        {
            return fixture.Create<LoggerSpecimenBuilder>();
        }
    }
}
