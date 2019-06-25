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
    class ExamRegistration
    {
        private IWebDriver driver;

        public ExamRegistration(IWebDriver driver)
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
        [FindsBy(How = How.LinkText, Using = "Male")]
        private IWebElement genderMale;

        [FindsByAll]
        [FindsBy(How = How.Id, Using = "Gender")]
        [FindsBy(How = How.LinkText, Using = "Female")]
        private IWebElement genderFemale;

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

        // [FindsBy(How = How.CssSelector, Using = "span#btn[.btn-group > :first-child:not(.dropdown-toggle):not(:last-child).btn {border - top - right - radius: 0px; border - bottom - right - radius: 0px;}")]
        #endregion PageElements
    }
}
