using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using POCFSBPT.Utilities;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssertLibrary;

namespace POCFSBPT.PageObjects
{
    public class CompactHome
    {
        private IWebDriver driver;

        // Error Strings

        private string emptyID = "The FSBPT ID field is required.";
        private string invalidID = "Please enter in the format (9999999).";
        private string emptyPass = "The Password field is required.";
        private string pageURL = ConfigurationManager.AppSettings["CompactInterface"];

        public CompactHome(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
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

        public void goToCompactHomePage()
        {
            driver.Navigate().GoToUrl(pageURL);
        }

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        public void EnterFsbptId(string id)
        {
            fsbptid.SendKeys(id);
        }

        public void EnterPassword(string pw)
        {
            password.SendKeys(pw);
        }

        public void ClickLogin()
        {
            loginbutton.Click();
        }

        public bool AssertPresent(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }

        public bool VerifyInvalidID()
        {
            if (fsbptiderror.Text.Contains(invalidID))
            {
                return true;
            }
            return false;
        }
    }
}
