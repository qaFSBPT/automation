using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCFSBPT.PageObjects;
using OpenQA.Selenium.Remote;

namespace Helpers
{
    public static class Helpers
    {
        // Create a Non-CAPTE user
        // Expects: Candidate Home Page to be loaded
        // Ends: Candidate Dashboard for the newly created user

        public static void CreateNonCAPTEUser(this RemoteWebDriver driver, string name)
        {
            AccountCreation createAccount = new AccountCreation(driver);
            //createAccount.goToAccountCreationPage();
            
            createAccount.SelectCountryOfEducation("USA");
            createAccount.selectSSN();
            createAccount.TypeInSSN("123456789");
            createAccount.SelectSchool("Unknown");
            createAccount.SelectDegreeLevel("Associates");
            createAccount.TypeInGraduationDate("1/1/2018");

            string[] names = name.Split();

            createAccount.TypeInLastName(names[1]);
            createAccount.TypeInFirstName(names[0]);



        }


    }
}
