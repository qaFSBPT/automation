using AssertLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace POCFSBPT.PageObjects
{
    class SchoolHome
    {

        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["SchoolInterface"];

        public SchoolHome(RemoteWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page Elements

        // Page Functions

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }
    }
}
