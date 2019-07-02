using AssertLibrary;
using OpenQA.Selenium;
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
        private IWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CandidateInterface"];

        public CandidateHome(IWebDriver driver)
        {
            this.driver = driver;
           // PageFactory.InitElements(driver, this);
        }

        // Page Elements

        [FindsBy(How = How.Id, Using = "FsbptId")]
        private IWebElement fsbptid;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginbutton;

        [FindsBy(How = How.Id, Using = "FsbptId-error")]
        public IWebElement fsbptiderror;

        // Page Functions

        public void goToCandidateHomePage()
        {
            driver.Navigate().GoToUrl(pageURL);
        }

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        public bool AssertPresent(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }
    }
}
