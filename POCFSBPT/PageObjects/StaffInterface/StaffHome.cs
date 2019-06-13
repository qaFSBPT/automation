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
    class StaffHome
    {

        private IWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["StaffInterface"];

        public StaffHome(IWebDriver driver)
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
