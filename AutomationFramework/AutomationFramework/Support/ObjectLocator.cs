using StructureMap;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Interfaces;
using OpenQA.Selenium;

namespace AutomationFramework.Support
{
    [ExcludeFromCodeCoverage]
    public static class ObjectLocator
    {
        public static IContainer container;

        public static void Intialize()
        {
            container = new Container(x =>
            {
                x.For<IExecutor>().Use<Executor>();
                x.For<IExecution>().Use<Execution>().Ctor<IContainer>().Is(container);
            });
        }
    }
}
