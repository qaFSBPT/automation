
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
    class AccountCreation :CandidateHome
    {
        private IWebDriver driver;

        // Error Message Strings

        private string ssnInvalid = "SSN must be 9 digits.";
        private string ssnAlpha = "SSN must be numeric and cannot start with 999.";
        private string ssnRequired = "The SSN field is required.";
        private string graduationDateInvalid = "The field Graduation Date must be a date.";
        public static string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/Account/Register";


        public AccountCreation(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        #region PageElements
        // Page Elements
        [FindsBy(How = How.Id, Using = "ssn-option")]
        private IWebElement ssnOption;

        [FindsBy(How = How.Id, Using = "Ssn")]
        private IWebElement ssn;

        [FindsBy(How = How.Id, Using = "Ssn-error")]
        private IWebElement ssnError;

        [FindsBy(How = How.Id, Using = "ain-option")]
        private IWebElement ainOption;

        [FindsBy(How = How.Id, Using = "CountryOfEducation")]
        private IWebElement countryOfEducation;
        private SelectElement selectCountryOfEducation
        {
            get
            {
                return new SelectElement(countryOfEducation);
            }
        }

        [FindsBy(How = How.ClassName, Using = "k-input")]
        private IWebElement school;

        [FindsBy(How = How.ClassName, Using = "k-i-arrow-s")]
        private IWebElement schoolArrow;

        [FindsBy(How = How.ClassName, Using = "k-item")]
        private List<IWebElement> schoolNameInList;
        
        [FindsBy(How = How.Id, Using = "GraduationDate")]
        private IWebElement graduationDate;

        [FindsBy(How = How.Id, Using = "GraduationDate-error")]
        private IWebElement graduationDateError;

        [FindsBy(How = How.Id, Using = "DegreeLevel")]
        private IWebElement degreeLevel;
        private SelectElement selectDegreeLevel
        {
            get
            {
                return new SelectElement(degreeLevel);
            }
        }

        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement firstName;

        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement lastName;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "Email-error")]
        private IWebElement emailError;

        [FindsBy(How = How.Id, Using = "DateOfBirth")]
        private IWebElement dob;

        [FindsBy(How = How.Id, Using = "DateOfBirth-error")]
        private IWebElement dobError;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "Password-error")]
        private IWebElement passwordError;

        [FindsBy(How = How.Id, Using = "ConfirmPassword")]
        private IWebElement confPassword;

        [FindsBy(How = How.Id, Using = "ConfirmPassword-error")]
        private IWebElement confPasswordError;

        // Page Functions
        #region PageFunctions
        private IWebElement GetSsn()
        {
            return ssn;
        }

        private void SetSsn(IWebElement value)
        {
            ssn = value;
        }

        public IWebElement GetGraduationDate()
        {
            return graduationDate;
        }

        public void SetGraduationDate(IWebElement value)
        {
            graduationDate = value;
        }

        public IWebElement GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(IWebElement value)
        {
            firstName = value;
        }

        public IWebElement GetLastName()
        {
            return lastName;
        }

        public void SetLastName(IWebElement value)
        {
            lastName = value;
        }

        public IWebElement GetEmail()
        {
            return email;
        }

        public void SetEmail(IWebElement value)
        {
            email = value;
        }

        public IWebElement GetDob()
        {
            return dob;
        }

        public void SetDob(IWebElement value)
        {
            dob = value;
        }

        public IWebElement GetPassword()
        {
            return password;
        }

        public void SetPassword(IWebElement value)
        {
            password = value;
        }

        public IWebElement GetConfPassword()
        {
            return confPassword;
        }

        public void SetConfPassword(IWebElement value)
        {
            confPassword = value;
        }

        #endregion PageElements


        public void goToAccountCreationPage()
        {
            driver.Navigate().GoToUrl(pageURL);
        }

        public void TypeInSSN(string social)
        {
            GetSsn().SendKeys(social);
        }

        public void selectSSN()
        {
            ssnOption.Click();
        }

        public void SelectAIN()
        {
            ainOption.Click();
        }

        public void VerifyInvalidSSN()
        {
            ValidateSSNError(ssnInvalid);
        }

        public void VerifyAlphaSSN()
        {
            ValidateSSNError(ssnAlpha);
        }

        public void VerifyRequiredSSN()
        {
            ValidateSSNError(ssnRequired);
        }

        public void VerifyInvalidGraduationDate()
        {
            ValidateGraduationDateError(graduationDateInvalid);
        }

        public void ClearSSN()
        {
            GetSsn().Clear();
        }

        public void SelectCountryOfEducation(string country)
        {
            selectCountryOfEducation.SelectByText(country);
        }

        public void TypeInGraduationDate(string date)
        {
            GetGraduationDate().SendKeys(date);
        }

        public void TypeInLastName(string name)
        {
            GetLastName().SendKeys(name);
        }

        public void TypeInFirstName(string name)
        {
            GetFirstName().SendKeys(name);
        }

        public void TypeInPassword(string pw)
        {
            GetPassword().SendKeys(pw);
        }

        public void TypeInConfirmPassword(string pw)
        {
            GetConfPassword().SendKeys(pw);
        }

        public void SelectDegreeLevel(string degree)
        {
            selectDegreeLevel.SelectByText(degree);
        }

        public void TypeInEmail(string address)
        {
            GetEmail().SendKeys(address);
        }

        public void TypeInDOB(string date)
        {
            GetDob().SendKeys(date);
        }

        public void SelectSchool(string schoolname)
        {
            schoolArrow.Click();
            school.SendKeys(schoolname);
            
            schoolNameInList.First().Click();

        }

        public void WaitForGraduationDateEnabled()
        {
            while (!graduationDate.Enabled) { }
        }

        

        private void ValidateSSNError(string err)
        {
            Assert.IsTrue(AssertPresent(ssnError));
            Assert.IsTrue(ssnError.Text.Contains(err));
        }

        private void ValidateGraduationDateError(string err)
        {
            Assert.IsTrue(AssertPresent(graduationDateError));
            Assert.IsTrue(graduationDateError.Text.Contains(err));
        }

        private void ValidateEmailError(string err)
        {
            Assert.IsTrue(AssertPresent(emailError));
            Assert.IsTrue(emailError.Text.Contains(err));
        }

        private void ValidateDOBError(string err)
        {
            Assert.IsTrue(AssertPresent(dobError));
            Assert.IsTrue(dobError.Text.Contains(err));
        }

        private void ValidatePasswordError(string err)
        {
            Assert.IsTrue(AssertPresent(passwordError));
            Assert.IsTrue(passwordError.Text.Contains(err));
        }

        private void ValidateConfPasswordError(string err)
        {
            Assert.IsTrue(AssertPresent(confPasswordError));
            Assert.IsTrue(confPasswordError.Text.Contains(err));
        }

        #endregion PageFunctions
    }
}
