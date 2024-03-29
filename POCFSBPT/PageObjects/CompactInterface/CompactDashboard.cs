﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT.PageObjects
{
    class CompactDashboard
    {

        private RemoteWebDriver driver;

        private string pageURL = ConfigurationManager.AppSettings["CompactInterface"];

        public CompactDashboard(RemoteWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // Page Elements


    }
}
