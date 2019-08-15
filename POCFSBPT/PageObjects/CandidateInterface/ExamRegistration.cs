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
    class ExamRegistration
    {
        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/SPA/ExamRegistration#update-customer-info";

        public ExamRegistration(RemoteWebDriver driver)
        {
            this.driver = driver;
            
        }

        // Page Elements
        #region PageElements
        private IWebElement firstName => driver.FindElementById("FirstName");

        private IWebElement middleName => driver.FindElementById("MiddleName");

        private IWebElement lastName => driver.FindElementById("LastName");

        private IWebElement mothersMaidenName => driver.FindElementById("MothersMaidenName");

        private IWebElement dateOfBirth => driver.FindElementById("birthdate");

        private IWebElement ssn => driver.FindElementById("SSN");

        private IWebElement email => driver.FindElementById("Email");

        private IWebElement secondaryEmail => driver.FindElementById("SecondaryEmail");

        private IWebElement mobilePhone => driver.FindElementById("MobilePhone");

        private IWebElement homePhone => driver.FindElementById("FirstName");

        private IWebElement receiveTextYes => driver.FindElementByLinkText("Yes");

        private IWebElement receiveTextNo => driver.FindElementByLinkText("No");

        private IWebElement workPhone => driver.FindElementById("WorkPhone");

        private IWebElement workPhoneExtension => driver.FindElementById("WorkPhoneExtension");

        private IWebElement gender => driver.FindElementById("Gender");
        private SelectElement selectGender
        {
            get
            {
                return new SelectElement(gender);
            }
        }

        private IWebElement primaryLanguage => driver.FindElementByName("PrimaryLanguage");
        private SelectElement selectPrimaryLanguage
        {
            get
            {
                return new SelectElement(primaryLanguage);
            }
        }
        
        private IWebElement otherPrimaryLanguage => driver.FindElementById("OtherPrimaryLanguage");

        private IWebElement ethnicity => driver.FindElementById("Ethnicity");
        private SelectElement selectEthnicity
        {
            get
            {
                return new SelectElement(ethnicity);
            }
        }
        
        private IWebElement otherEthnicity => driver.FindElementById("OtherEthnicity");

        private IWebElement nameConfirmationCheckbox => driver.FindElementById("name-confirmation");

        private IWebElement addressLine1 => driver.FindElementById("AddressLine1");

        private IWebElement addressLine2 => driver.FindElementById("AddressLine2");

        private IWebElement country => driver.FindElementById("Country");
        private SelectElement selectCountry
        {
            get
            {
                return new SelectElement(country);
            }
        }

        private IWebElement city => driver.FindElementById("City");

        private IWebElement stateProvince => driver.FindElementById("StateProvince");
        private SelectElement selectStateProvince
        {
            get
            {
                return new SelectElement(stateProvince);
            }
        }

        private IWebElement otherState => driver.FindElementById("OtherState");

        private IWebElement usPostalCode => driver.FindElementById("USPostalCode");

        private IWebElement canadianPostalCode => driver.FindElementById("CanadianPostalCode");

        private IWebElement otherPostalCode => driver.FindElementById("OtherPostalCode");

        private IWebElement zipPlus4 => driver.FindElementById("Zip4");

        private IWebElement noReleaseNPTEScores => driver.FindElementByCssSelector("label#Active: SchoolAuthorizeNPTEScoreRelease()==false");

        private IWebElement yesReleaseNPTEScores => driver.FindElementByCssSelector("label#Active: SchoolAuthorizeNPTEScoreRelease()");
        
        private IWebElement cancelButton => driver.FindElementByXPath("//*[@id='main - body']/div[3]/div/div[1]/button");

        private IWebElement continueButton => driver.FindElementByXPath("//*[@id='updateProfile']");

        #endregion PageElements

        // Page Functions
        #region PageFunctions
        public void verifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        private IWebElement getFirstName()
        {
            return firstName;
        }

        private IWebElement getMiddleName()
        {
            return middleName;
        }

        private IWebElement getLastName()
        {
            return lastName;
        }

        private IWebElement getDateOfBirth()
        {
            return dateOfBirth;
        }

        private IWebElement getEmail()
        {
            return email;
        }

        private IWebElement getSecondaryEmail()
        {
            return secondaryEmail;
        }

        private IWebElement getMobilePhone()
        {
            return mobilePhone;
        }

        private IWebElement getHomePhone()
        {
            return homePhone;
        }

        private IWebElement getWorkPhone()
        {
            return workPhone;
        }

        private IWebElement getExtension()
        {
            return workPhoneExtension;
        }

        private IWebElement getGender()
        {
            return gender;
        }

        private IWebElement getNativeLanguage()
        {
            return primaryLanguage;
        }

        private IWebElement getOtherLanguage()
        {
            return otherPrimaryLanguage;
        }

        private IWebElement getEthnicity()
        {
            return ethnicity;
        }

        private IWebElement getOtherEthnicity()
        {
            return otherEthnicity;
        }

        private IWebElement getAddressLine1()
        {
            return addressLine1;
        }

        private IWebElement getAddressLine2()
        {
            return addressLine2;
        }

        private IWebElement getCountry()
        {
            return country;
        }

        private IWebElement getCity()
        {
            return city;
        }

        private IWebElement getStateProvince()
        {
            return stateProvince;
        }

        private IWebElement getUSPostalCode()
        {
            return usPostalCode;
        }

        private IWebElement getCanadianPostalCode()
        {
            return canadianPostalCode;
        }

        private IWebElement getOtherPostalCode()
        {
            return otherPostalCode;
        }

        private IWebElement getZipPlus4()
        {
            return zipPlus4;
        }

        public void TypeFirstName(string name)
        {
            getFirstName().SendKeys(name);
        }

        public void TypeMiddleName(string name)
        {
            getMiddleName().SendKeys(name);
        }

        public void TypeLastName(string name)
        {
            getLastName().SendKeys(name);
        }

        public void TypeDateOfBirth(string dob)
        {
            getDateOfBirth().SendKeys(dob);
        }

        public void TypePrimaryEmail(string email)
        {
            getEmail().SendKeys(email);
        }

        public void TypeSecondaryEmail(string email)
        {
            getSecondaryEmail().SendKeys(email);
        }

        public void TypeMobilePhone(string number)
        {
            getMobilePhone().SendKeys(number);
        }

        public void TypeHomePhone(string number)
        {
            getHomePhone().SendKeys(number);
        }

        public void TypeWorkPhone(string number)
        {
            getWorkPhone().SendKeys(number);
        }

        public void TypeWorkExtension(string number)
        {
            getExtension().SendKeys(number);
        }

        public void TypeAddressLine1(string address)
        {
            getAddressLine1().SendKeys(address);
        }

        public void TypeAddressLine2(string address)
        {
            getAddressLine2().SendKeys(address);
        }

        public void TypeCity(string city)
        {
            getCity().SendKeys(city);
        }

        public void TypeUSPostalCode(string address)
        {
            getUSPostalCode().SendKeys(address);
        }

        public void TypeCanadianPostalCode(string address)
        {
            getCanadianPostalCode().SendKeys(address);
        }

        public void TypeOtherPostalCode(string address)
        {
            getOtherPostalCode().SendKeys(address);
        }

        public void TypeZipPlus4(string address)
        {
            getZipPlus4().SendKeys(address);
        }

        public void SelectGenderMale()
        {
            selectGender.SelectByText("Male");
        }

        public void SelectGenderFemale()
        {
            selectGender.SelectByText("Female");
        }

        public void CheckNameValidation()
        {
            nameConfirmationCheckbox.Click();
        }

        public void SelectReleaseYes()
        {
            yesReleaseNPTEScores.Click();
        }

        public void SelectReleaseNo()
        {
            noReleaseNPTEScores.Click();
        }

        public void ClickCancel()
        {
            cancelButton.Click();
        }

        public void ClickContinue()
        {
            continueButton.Click();
        }

        public void SelectNotificationsYes()
        {
            receiveTextYes.Click();
        }

        public void SelectNotificationsNo()
        {
            receiveTextNo.Click();
        }

        #endregion PageFunctions
    }
}
