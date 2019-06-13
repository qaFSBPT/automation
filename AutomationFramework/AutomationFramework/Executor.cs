using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationFramework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework
{
    /// <summary>
    /// Implementation of <see cref="IExecutor"/>
    /// </summary>
    public class Executor : IExecutor
    {
        /// <summary>
        /// Clicks the given WebElement. <see cref="IWebElement.Click"/>
        /// </summary>
        /// <param name="element">WebElement to click</param>
        /// <returns>Sucess</returns>
        public bool Click(IWebElement element)
        {
            Validators.IsArgumentNull(element);
            try
            {
                element.Click();
                return true;
            } catch(Exception ex)
            {
                // TODO: error handling & logging
                return false;
                //throw ex;
            }
        }

        /// <summary>
        /// Sends a string to the given WebElement. <see cref="IWebElement.SendKeys(string)"/>
        /// </summary>
        /// <param name="element">WebElement to send text too</param>
        /// <param name="toSend">Text to send</param>
        /// <returns>Success</returns>
        public bool SendKeys(IWebElement element, string toSend)
        {
            Validators.IsArgumentNull(element);
            Validators.IsArgumentEmpty(toSend);
            try
            {
                element.SendKeys(toSend);
                return true;
            } catch(Exception ex)
            {
                // TODO: error handling & logging
                return false;
                //throw ex;
            }
        }

        /// <summary>
        /// Selects an item from the WebElement based on the index. <see cref="SelectElement(IWebElement, int)"/>
        /// </summary>
        /// <param name="element">WebElement to select from</param>
        /// <param name="index">The selection critera/index</param>
        /// <returns>Success</returns>
        public bool SelectElement(IWebElement element, int index)
        {
            Validators.IsArgumentNull(element);
            try
            {
                SelectElement selection = new SelectElement(element);
                selection.SelectByIndex(index);
                return true;
            } catch(Exception ex)
            {
                // TODO: error handling & logging
                return false;
                //throw ex;
            }
        }
        /// <summary>
        /// Checks if the WebElements is present or not.
        /// <see cref="IWebElement.Enabled"/>
        /// <see cref="IWebElement.Displayed"/>
        /// </summary>
        /// <param name="element">WebElement to check</param>
        /// <returns>Success</returns>

        public bool AssertPresent(IWebElement element)
        {
            Validators.IsArgumentNull(element);
            try
            {
                return element.Enabled && element.Displayed;
            } catch(Exception ex)
            {
                // TODO: error handling & logging
                return false;
                //throw ex;
            }
        }
    }
}
