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
    class PaymentConfirmation
    {
        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/SPA/ExamRegistration#customer-payment";

        public PaymentConfirmation(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Elements
        #region PageElements
        private IWebElement editProfile => driver.FindElementByXPath("//*[@id='customer - verification']/div[2]/div[1]/button");
        private IWebElement editPurchase => driver.FindElementByXPath("//*[@id='customer - verification']/div[2]/div[2]/div/div/button");
        private IWebElement editPayment => driver.FindElementByXPath("//*[@id='customer - verification']/div[2]/div[3]/div/div[1]/div[1]");
        private IWebElement iAccept => driver.FindElementByXPath("//*[@id='customer - verification']/div[2]/div[4]/div/div/div/div/label/input");
        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void ClickEditProfile()
        {
            editProfile.Click();
        }
        public void ClickEditPurchse()
        {
            editPayment.Click();
        }
        public void ClickEditPayment()
        {
            editPayment.Click();
        }
        public void SelectIAccept()
        {
            if (!iAccept.Selected) iAccept.Click();
        }
        public void DeselectIAccept()
        {
            if (iAccept.Selected) iAccept.Click();
        }
        #endregion PageFunctions
    }
}
