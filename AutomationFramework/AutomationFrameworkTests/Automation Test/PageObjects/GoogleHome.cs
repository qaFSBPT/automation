using AutomationFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFrameworkTests.PageObjects
{
    public class GoogleHome
    {
        private IWebDriver driver;
        public GoogleHome(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "lst-ib")]
        public IWebElement SearchBar { get; set; }

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement Submit { get; set; }

    }
}
