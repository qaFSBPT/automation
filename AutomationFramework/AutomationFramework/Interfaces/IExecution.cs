using OpenQA.Selenium;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Interfaces
{
    /// <summary>
    /// Creates the excution process from the CSV
    /// </summary>
    public interface IExecution
    {
        /// <summary>
        /// Uses an already existing PageObject/Factory to execute the steps
        /// </summary>
        /// <param name="instance">PageObject/Factory to use</param>
        /// <param name="steps">Steps from the CSV</param>
        /// <returns></returns>
        List<bool> Run(object instance, Dictionary<string, string> steps);

        /// <summary>
        /// Uses the built elements <see cref="IBuilder"/> to execute the steps
        /// </summary>
        /// <param name="elements">WebElements used in execution</param>
        /// <param name="steps">Steps from the CSV</param>
        /// <returns>List of what actions executed properly</returns>
        List<bool> Run(Dictionary<string, IWebElement> elements, Dictionary<string, string> steps);

        /// <summary>
        /// Groups the steps into actions that can be executed
        /// </summary>
        /// <param name="steps">User defined steps</param>
        /// <returns>Executable actions</returns>
        List<List<string>> GroupActions(Dictionary<string, string> steps);
    }
}
