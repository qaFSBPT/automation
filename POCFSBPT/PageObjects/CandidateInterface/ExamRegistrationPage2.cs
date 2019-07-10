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
    class ExamRegistrationPage2
    {
        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/SPA/ExamRegistration#select-event-date";

        public ExamRegistrationPage2(RemoteWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page Elements
        #region PageElements

        [FindsBy(How = How.Id, Using = "JurisdictionId")]
        private IWebElement jurisdictionDropdown;
        private SelectElement selectJurisdiction
        {
            get
            {
                return new SelectElement(jurisdictionDropdown);
            }
        }

        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void SelectJurisdiction(string jurisdiction)
        {
            selectJurisdiction.SelectByText(jurisdiction);
        }

        #endregion PageFunctions
    }
}
