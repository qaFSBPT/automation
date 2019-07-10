
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
    class AccountCreation
    {
        private RemoteWebDriver driver;
        

        // Error Message Strings

        private string ssnInvalid = "SSN must be 9 digits.";
        private string ssnAlpha = "SSN must be numeric and cannot start with 999.";
        private string ssnRequired = "The SSN field is required.";
        private string graduationDateInvalid = "The field Graduation Date must be a date.";
        public static string pageURL = ConfigurationManager.AppSettings["CandidateInterface"] + "/Account/Register";


        public AccountCreation(RemoteWebDriver driver)
        {
            this.driver = driver;
           
        }

        // Page Elements
        #region PageElements

        private IWebElement ssnOption => driver.FindElementByXPath("//*[@id=\"ssn-option\"]");

        private IWebElement ssn => driver.FindElementById("Ssn");
        
        private IWebElement ssnError => driver.FindElementById("Ssn-error");

        private IWebElement ainOption => driver.FindElementById("ain-option");

        private IWebElement countryOfEducation => driver.FindElementById("CountryOfEductaion");
        
        private IWebElement school => driver.FindElementByClassName("k-input");

        private IWebElement schoolArrow => driver.FindElementByClassName("k-i-arrow-s");

        private IWebElement schoolNameInList => driver.FindElementByClassName("k-i-arrow-s");
        
        private IWebElement graduationDate => driver.FindElementById("GraduationDate");

        private IWebElement graduationDateError => driver.FindElementById("GraduationDate-error");

        private IWebElement degreeLevel => driver.FindElementById("DegreeLevel");

        private IWebElement firstName => driver.FindElementById("FirstName");

        private IWebElement lastName => driver.FindElementById("LastName");

        private IWebElement email => driver.FindElementById("Email");

        private IWebElement emailError => driver.FindElementById("Email-error");

        private IWebElement dob => driver.FindElementById("DateOfBirth");

        private IWebElement dobError => driver.FindElementById("DateOfBirth-error");

        private IWebElement password => driver.FindElementById("Password");
        
        private IWebElement passwordError => driver.FindElementById("Password-error");

        private IWebElement confPassword => driver.FindElementById("ConfirmPassword");
        
        private IWebElement confPasswordError => driver.FindElementById("ConfirmPassword-error");

        #endregion PageElements

        // Page Functions
        #region PageFunctions

        public void VerifyPage()
        {
            Assert.Equals(pageURL, driver.Url);
        }

        private IWebElement getSSNSelect()
        {
            return ssnOption;
        }

        private IWebElement GetSsn()
        {
            return ssn;
        }

        private void SetSsn(string value)
        {
            ssn.SendKeys(value);
        }

        public IWebElement GetGraduationDate()
        {
            return graduationDate;
        }

        public void SetGraduationDate(string value)
        {
            graduationDate.SendKeys(value);
        }

        public IWebElement GetFirstName()
        {
            return firstName;
        }

        public void SetFirstName(string value)
        {
            firstName.SendKeys(value);
        }

        public IWebElement GetLastName()
        {
            return lastName;
        }

        public void SetLastName(string value)
        {
            lastName.SendKeys(value);
        }

        public IWebElement GetEmail()
        {
            return email;
        }

        public void SetEmail(string value)
        {
            email.SendKeys(value);
        }

        public IWebElement GetDob()
        {
            return dob;
        }

        public void SetDob(string value)
        {
            dob.SendKeys(value);
        }

        public IWebElement GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password.SendKeys(value);
        }

        public IWebElement GetConfPassword()
        {
            return confPassword;
        }

        public void SetConfPassword(string value)
        {
            confPassword.SendKeys(value);
        }

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
        
        SelectElement selectCountryOfEducation = new SelectElement(countryOfEducation);
            
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
            SelectElement selectDegreeLevel = new SelectElement(degreeLevel);

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
            
            schoolNameInList.Click();

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

        public bool AssertPresent(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }


        #endregion PageFunctions
    }
}
