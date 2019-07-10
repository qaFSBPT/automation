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
            PageFactory.InitElements(driver, this);
        }

        // Page Elements
        #region PageElements
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "MiddleName")]
        private IWebElement middleName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = "MothersMaidenName")]
        private IWebElement mothersMaidenName;

        [FindsBy(How = How.Id, Using = "birthdate")]
        private IWebElement dateOfBirth;

        [FindsBy(How = How.Id, Using = "SSN")]
        private IWebElement ssn;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "SecondaryEmail")]
        private IWebElement secondaryEmail;

        [FindsBy(How = How.Id, Using = "MobilePhone")]
        private IWebElement mobilePhone;

        [FindsBy(How = How.Id, Using = "HomePhone")]
        private IWebElement homePhone;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "ReceiveTextMessages")]
        [FindsBy(How = How.LinkText, Using = "Yes")]
        private IWebElement receiveTextYes;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "ReceiveTextMessages")]
        [FindsBy(How = How.LinkText, Using = "No")]
        private IWebElement receiveTextNo;

        [FindsBy(How = How.Id, Using = "WorkPhone")]
        private IWebElement workPhone;

        [FindsBy(How = How.Id, Using = "WorkPhoneExtension")]
        private IWebElement workPhoneExtension;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "Gender")]
        private IWebElement gender;
        private SelectElement selectGender
        {
            get
            {
                return new SelectElement(gender);
            }
        }

        [FindsBy(How = How.Name, Using = "PrimaryLanguage")]
        private IWebElement primaryLanguage;
        private SelectElement selectPrimaryLanguage
        {
            get
            {
                return new SelectElement(primaryLanguage);
            }
        }

        [FindsBy(How = How.Id, Using = "OtherPrimaryLanguage")]
        private IWebElement otherPrimaryLanguage;

        [FindsBy(How = How.Id, Using = "Ethnicity")]
        private IWebElement ethnicity;
        private SelectElement selectEthnicity
        {
            get
            {
                return new SelectElement(ethnicity);
            }
        }

        [FindsBy(How = How.Id, Using = "OtherEthnicity")]
        private IWebElement otherEthnicity;

        [FindsBy(How = How.Id, Using = "name-confirmation")]
        private IWebElement nameConfirmationCheckbox;

        [FindsBy(How = How.Id, Using = "AddressLine1")]
        private IWebElement addressLine1;

        [FindsBy(How = How.Id, Using = "AddressLine2")]
        private IWebElement addressLine2;

        [FindsBy(How = How.Id, Using = "Counrty")]
        private IWebElement country;
        private SelectElement selectCountry
        {
            get
            {
                return new SelectElement(country);
            }
        }

        [FindsBy(How = How.Id, Using = "City")]
        private IWebElement city;

        [FindsBy(How = How.Id, Using = "StateProvince")]
        private IWebElement stateProvince;
        private SelectElement selectStateProvince
        {
            get
            {
                return new SelectElement(stateProvince);
            }
        }

        [FindsBy(How = How.Id, Using = "OtherState")]
        private IWebElement otherState;

        [FindsBy(How = How.Id, Using = "USPostalCode")]
        private IWebElement usPostalCode;

        [FindsBy(How = How.Id, Using = "CanadianPostalCode")]
        private IWebElement canadianPostalCode;

        [FindsBy(How = How.Id, Using = "OtherPostalCode")]
        private IWebElement otherPostalCode;

        [FindsBy(How = How.Id, Using = "Zip4")]
        private IWebElement zipPlus4;

        [FindsByAll]
        [FindsBy(How = How.CssSelector, Using = "label#Active: SchoolAuthorizeNPTEScoreRelease()==false")]
        [FindsBy(How = How.LinkText, Using = "No")]
        private IWebElement noReleaseNPTEScores;

        [FindsByAll]
        [FindsBy(How = How.CssSelector, Using = "label#Active: SchoolAuthorizeNPTEScoreRelease()")]
        [FindsBy(How = How.LinkText, Using = "Yes")]
        private IWebElement yesReleaseNPTEScores;

        [FindsBy(How = How.XPath, Using = "//*[@id='main - body']/div[3]/div/div[1]/button")]
        private IWebElement cancelButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='updateProfile']")]
        private IWebElement continueButton;

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
