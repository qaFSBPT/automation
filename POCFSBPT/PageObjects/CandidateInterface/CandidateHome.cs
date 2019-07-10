using AssertLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT.PageObjects
{
    class CandidateHome
    {
        private RemoteWebDriver driver;

        private readonly string pageURL = ConfigurationManager.AppSettings["CandidateInterface"];

        public CandidateHome(RemoteWebDriver driver)
        {
            this.driver = driver;

        }

        // Page Elements
        #region PageElements
         private IWebElement fsbptid => driver.FindElementById("FsbptId");

         private IWebElement password => driver.FindElementById("Password");

        private IWebElement loginbutton => driver.FindElementById("login-button");

        private IWebElement fsbptiderror => driver.FindElementById("FsbptId-error");

        private IWebElement createLink => driver.FindElementByXPath("//*[@id='LoginForm']/div/div[1]/div[2]/div/div/div/div[2]/ul/li[2]/a");
        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void goToCandidateHomePage()
        {
           driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["CandidateInterface"]);
        }

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        public bool AssertPresent(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public void ClickCreateAccountLink()
        {
            createLink.Click();
        }
        #endregion PageFunctions
    }
}
