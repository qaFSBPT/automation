using AutomationFramework.Helpers;
using AutomationFramework.Interfaces;
using AutomationFramework.Support;
using OpenQA.Selenium;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework
{
    public class Automation
    {
        private IWebDriver driver;

        private int row;
        private string path;
        private string elementsPath = string.Empty;
        private string url;

        public Automation(IWebDriver driver, string path, string url, int row)
        {
            Validators.IsArgumentNull(driver, row);
            Validators.IsArgumentEmpty(path, url);
            ObjectLocator.Intialize();

            this.driver = driver;
            this.row = row;
            this.path = path;
            this.url = url;
        }

        public Automation(IWebDriver driver, string path, string url)
        {
            Validators.IsArgumentNull(driver);
            Validators.IsArgumentEmpty(path, url);
            ObjectLocator.Intialize();

            this.driver = driver;
            this.path = path;
            this.row = default(int);
            this.url = url;
        }

        public Automation(IWebDriver driver, string stepsPath, string elementsPath, string url)
        {
            Validators.IsArgumentNull(driver);
            Validators.IsArgumentEmpty(stepsPath, elementsPath, url);
            ObjectLocator.Intialize();

            this.driver = driver;
            this.path = stepsPath;
            this.elementsPath = elementsPath;
            this.row = default(int);
            this.url = url;
        }
        public Automation(IWebDriver driver, string stepsPath, string elementsPath, string url, int row)
        {
            Validators.IsArgumentNull(driver);
            Validators.IsArgumentEmpty(stepsPath, elementsPath, url);
            ObjectLocator.Intialize();

            this.driver = driver;
            this.path = stepsPath;
            this.elementsPath = elementsPath;
            this.row = row;
            this.url = url;
        }

        public Dictionary<string, List<bool>> ExcuteTest()
        {
            Dictionary<string, Dictionary<string, string>> stepsData;
            Dictionary<string, List<bool>> results = new Dictionary<string, List<bool>>();
            Dictionary<string, IWebElement> webElements = null;
            PageBuilder builder;

            IExecution execute = ObjectLocator.container.GetInstance<IExecution>();

            stepsData = this.row != default(int) ? DataReader.ReadCSVKV(path, row) : DataReader.ReadCSVKV(path, default(int));

            foreach(var step in stepsData)
            {
                driver.Navigate().GoToUrl(url);
                Dictionary<string, string> steps = step.Value;
                if (!string.IsNullOrEmpty(elementsPath))
                {
                    driver.Navigate().GoToUrl(url);
                    builder = new PageBuilder(elementsPath, driver);
                    webElements = builder.pageObjects;
                    steps.Remove(steps.Keys.First());
                    results[step.Key] = execute.Run(webElements, steps);
                }
                else
                {
                    var instance = InstanceCreator.Create(steps[steps.Keys.FirstOrDefault()], driver);
                    steps.Remove(steps.Keys.First());
                    results[step.Key] = execute.Run(instance, steps);
                }
            }
            return results;
        }
    }
}
