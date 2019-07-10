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
    class StaffHome
    {

        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["StaffInterface"];

        public StaffHome(RemoteWebDriver driver)
        {
            this.driver = driver;
            
        }

        // Page Elements

        // Page Functions

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }
    }
}
