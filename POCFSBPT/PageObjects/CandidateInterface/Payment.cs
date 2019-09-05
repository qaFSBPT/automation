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
    class Payment
    {
        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/SPA/ExamRegistration#customer-payment";

        public Payment(RemoteWebDriver driver)
        {
            this.driver = driver;
        }

        // Page Elements
        #region PageElements

        private IWebElement payNow => driver.FindElementByXPath("//*[@id='customer - payment']/div[2]/div[1]/div/div/div/div[1]");
        private IWebElement payLater => driver.FindElementByXPath("//*[@id='customer - payment']/div[2]/div[1]/div/div/div/div[2]");
        private IWebElement nameOnCard => driver.FindElementById("CCName");
        private IWebElement securityCode => driver.FindElementById("CCSecurityCode");
        private IWebElement cardNumber => driver.FindElementById("CCNumber");
        private IWebElement expirationDate => driver.FindElementById("ExpirationDate");
        private IWebElement useAddressOnRecord => driver.FindElementByXPath("//*[@id='customer - payment']/div[2]/div[3]/div[1]/div/button");
        private IWebElement address1 => driver.FindElementById("BillingAdress1");
        private IWebElement address2 => driver.FindElementById("BillingAdress2");
        private IWebElement country => driver.FindElementById("BillingCountry");
        private SelectElement selectCountry
        {
            get
            {
                return new SelectElement(country);
            }
        }
        private IWebElement state => driver.FindElementById("BillingStateProvince");
        private SelectElement selectState
        {
            get
            {
                return new SelectElement(state);
            }
        }
        private IWebElement city => driver.FindElementById("BillingCity");
        private IWebElement zip => driver.FindElementById("BillingPostalCode");

        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void verifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        public IWebElement GetNameOnCard()
        {
            return nameOnCard;
        }
        public void TypeNameOnCard(string name)
        {
            nameOnCard.SendKeys(name);
        }
        public IWebElement GetSecurityCode()
        {
            return securityCode;
        }
        public void TypeSecurityCode(string code)
        {
            securityCode.SendKeys(code);
        }
        public IWebElement GetCardNumber()
        {
            return cardNumber;
        }
        public void TypeCardNumber(string number)
        {
            cardNumber.SendKeys(number);
        }
        public IWebElement GetExpirationDate()
        {
            return expirationDate;
        }
        public void TypeExpirationDate(string date)
        {
            expirationDate.SendKeys(date);
        }
        public IWebElement GetAddress1()
        {
            return address1;
        }
        public void TypeAddress1(string address)
        {
            address1.SendKeys(address);
        }
        public IWebElement GetAddress2()
        {
            return address2;
        }
        public void TypeAddress2(string address)
        {
            address2.SendKeys(address);
        }
        public IWebElement GetCity()
        {
            return city;
        }
        public void TypeCity(string town)
        {
            city.SendKeys(town);
        }
        public IWebElement GetPostalCode()
        {
            return zip;
        }
        public void TypePostalCode(string code)
        {
            zip.SendKeys(code);
        }
        public void SelectCountry(string nation)
        {
            selectCountry.SelectByText(nation);
        }
        public void SelectState(string province)
        {
            selectState.SelectByText(province);
        }
        #endregion PageFunctions
    }
}