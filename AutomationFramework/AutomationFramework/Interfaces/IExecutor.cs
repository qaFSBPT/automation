using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework
{
    /// <summary>
    /// Executes the the specified actions/steps from the CSV
    /// </summary>
    public interface IExecutor
    {
        /// <summary>
        /// <see cref="IWebElement.SendKeys(string)"/>
        /// </summary>
        /// <param name="element">The WebElement to sendkeys too</param>
        /// <param name="toSend">THe string to send</param>
        /// <returns></returns>
        bool SendKeys(IWebElement element, string toSend);

        /// <summary>
        /// <see cref="IWebElement.Click"/>
        /// </summary>
        /// <param name="element">The WebElement to click</param>
        /// <returns>Success</returns>
        bool Click(IWebElement element);

        /// <summary>
        /// <see cref="SelectElement(IWebElement, int)"/>
        /// </summary>
        /// <param name="element">WebElement to select from</param>
        /// <param name="index">The selection criteria</param>
        /// <returns>Sucess</returns>
        bool SelectElement(IWebElement element, int index);

        /// <summary>
        /// Checks whether the WebElement is present
        /// </summary>
        /// <param name="element">WebElement to check</param>
        /// <returns>Success</returns>
        bool AssertPresent(IWebElement element);
    }
}
