using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCFSBPT.PageObjects;
using Helpers;
using OpenQA.Selenium.Remote;

namespace POCFSBPT.Tests.Candidate_Tests
{
    [TestClass]
    public class RegistrationTests
    {

        private RemoteWebDriver driver;
        

        [TestInitialize]
        public void Setup()
        {
            
            driver = new InternetExplorerDriver();
            CandidateHome page = new CandidateHome(driver);
            page.goToCandidateHomePage();
        }

        //  Non-CAPTE Registration
        [TestMethod]
        public void Registration_NonCAPTE()
        {
            CandidateHome page = new CandidateHome(driver);
            page.ClickCreateAccountLink();


            AccountCreation page2 = new AccountCreation(driver);
            //page2.VerifyPage();

            driver.CreateNonCAPTEUser("bob jones");
        }
    }
}
