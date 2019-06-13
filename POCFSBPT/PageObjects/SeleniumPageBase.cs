using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCFSBPT.PageObjects
{
    public class SeleniumPageBase
    {
        protected IWebDriver myWebDriver;
        public SeleniumPageBase(IWebDriver webDriver)
        {
            myWebDriver = webDriver;
        }


        /*protected int browserIndex
        {
            get
            {
                return // Code to get Browser index/;
            }
        }*/
    }
}
