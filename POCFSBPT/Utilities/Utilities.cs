using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT.Utilities
{
    class Utilities
    {
        private IWebDriver driver;

        public bool IsElementPresent(By locator)
        {
            //Set the timeout to something low
            // driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(100));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);

            try
            {
                driver.FindElement(locator);
                //If element is found set the timeout back and return true
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(20000));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(20000);
                return true;
            }
            catch (NoSuchElementException)
            {
                //If element isn't found, set the timeout and return false
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(20000));
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(20000);
                return false;
            }
        }
    }
}
