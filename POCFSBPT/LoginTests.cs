using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using POCFSBPT.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT
{
    public class LoginTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new InternetExplorerDriver();
        }
        [Test]
        public void FSBPTID_Too_Short()
        {
            CompactHome home = new CompactHome(driver);
            home.goToCompactHomePage();
            home.EnterFsbptId("01234");
            home.EnterPassword("P@ssw0rd");
            home.AssertPresent(home.fsbptiderror);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
