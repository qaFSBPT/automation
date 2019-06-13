using AutomationFramework.Helpers;
using AutomationFramework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework
{
    /// <summary>
    /// <see cref="IBuilder"/>
    /// </summary>
    public class PageBuilder : IBuilder
    {
        public Dictionary<string, IWebElement> pageObjects { get; set; }
        private string elementsData;
        private IWebDriver driver;

        /// <summary>
        /// Creates an instance of PageBuilder
        /// </summary>
        /// <param name="elementsDataPath">Path to the CSV containing the page elements</param>
        /// <param name="driver">driver use to execute the actions</param>
        public PageBuilder(string elementsDataPath, IWebDriver driver)
        {
            Validators.IsArgumentEmpty(elementsDataPath);
            Validators.IsArgumentNull(driver);

            this.elementsData = elementsDataPath;
            this.driver = driver;
            this.pageObjects = Build();
        }

        /// <summary>
        /// Builds the <see cref="IWebElement"/> from a CSV.
        /// Where the CSV has the format of (By | Locator | NameOfVariable)
        /// </summary>
        /// <returns>(user specified name, IWebElement)</returns>
        public Dictionary<string, IWebElement> Build()
        {
            // By : Locator : NameOfVariable
            Dictionary<string, IWebElement> toReturn = new Dictionary<string, IWebElement>();

            List<string[]> elementsToBuild = DataReader.ReadCSV(elementsData);
            elementsToBuild.RemoveAt(0);

            try
            {
                foreach(var element in elementsToBuild)
                {
                    // Create element 
                    var locator = typeof(By).GetMethod(element[0]).Invoke(null, new object[] { element[1] });
                    IWebElement myElement = driver.FindElement((By)locator);

                    toReturn.Add(element[2], myElement);
                }
            } 
            catch(NoSuchElementException ex)
            {
                // TODO: error handling & logging
                throw ex;
            }

            return toReturn;
        }
    }
}
