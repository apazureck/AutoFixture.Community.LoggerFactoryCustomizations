using AutoFixture.Kernel;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AutoFixture.Customizations.LoggerFactoryCustomization
{
    internal class LoggerSpecimenBuilder : ISpecimenBuilder
    {
        private readonly ILoggerFactory loggerFactory;

        public LoggerSpecimenBuilder(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
        }
        public object Create(object request, ISpecimenContext context)
        {
            if (request is System.Reflection.ParameterInfo i)
            {
                if (typeof(ILogger).IsAssignableFrom(i.ParameterType))
                {
                    var gtype = typeof(Logger<>).MakeGenericType(i.ParameterType.GetGenericArguments().First());
                    return Activator.CreateInstance(gtype, new object[] { loggerFactory });
                } else if(typeof(ILoggerFactory).IsAssignableFrom(i.ParameterType))
                {
                    return loggerFactory;
                }
            }
            return new NoSpecimen();
        }
    }
}