using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Interfaces
{
    /// <summary>
    /// Builds the <see cref="IWebElement"/> from a CSV
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Builds the <see cref="IWebElement"/> from a CSV
        /// </summary>
        /// <returns>user specified name, IWebElement</returns>
        Dictionary<string, IWebElement> Build();
    }
}
