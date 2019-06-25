
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
    class PEATRegistration :ExamRegistration
    {
        private IWebDriver driver;

        public PEATRegistration(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page Elements
        #region PageElements

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "ReceivedSchoolAccommodations")]
        [FindsBy(How = How.LinkText, Using = "Yes")]
        private IWebElement receivedAccomodationsYes;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "ReceivedSchoolAccommodations")]
        [FindsBy(How = How.LinkText, Using = "No")]
        private IWebElement receivedAccomodationsNo;

        #endregion PageElements

        // Page Functions
        #region PageFunctions

        public void SelectAccommodationsYes()
        {
            receivedAccomodationsYes.Click();
        }

        public void SelectAccommodationsNo()
        {
            receivedAccomodationsNo.Click();
        }

        #endregion PageFunctions
    }
}
