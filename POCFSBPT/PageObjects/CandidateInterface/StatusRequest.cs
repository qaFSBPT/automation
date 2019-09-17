
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
    class StatusRequest
    {
        private RemoteWebDriver driver;

        public StatusRequest(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Elements
        #region PageElements

        private IWebElement peatTab => driver.FindElementById("peat-tab");
        private IWebElement registrationTab => driver.FindElementById("registrations-tab");
        private IWebElement scoreTransferTab => driver.FindElementById("score-transfers_tab");
        private IWebElement viewAllTab => driver.FindElementById("view-all-tab");
        private IWebElement backButton => driver.FindElementById("detail-pane-back-button");

        #endregion PageElements
        //Page Functions
        #region PageFunctions
        public void ClickPeatTab()
        {
            peatTab.Click();
        }
        public void ClickRegistrationTab()
        {
            registrationTab.Click();
        }
        public void ClickScoreTransferTab()
        {
            scoreTransferTab.Click();
        }
        public void ClickViewAllTab()
        {
            viewAllTab.Click();
        }
        public void ClickBackButton()
        {
            backButton.Click();
        }
        #endregion PageFunctions
    }
}
