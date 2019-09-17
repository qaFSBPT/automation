
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POCFSBPT.PageObjects
{
    class Receipt
    {
        private RemoteWebDriver driver;

        public Receipt(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        #region PageElements
        // Page Elements

        private IWebElement printReceipt => driver.FindElementById("print");

        private IWebElement done => driver.FindElementByXPath("//*[@id='main - body']/div[3]/div/div[2]/button[3]");

        #endregion PageElements

        #region PageFunctions
        // Page Functions
        public void ClickPrintButton()
        {
            printReceipt.Click();
        }

        public void ClickDoneButton()
        {
            done.Click();
        }
        #endregion PageFunctions
    }
}
