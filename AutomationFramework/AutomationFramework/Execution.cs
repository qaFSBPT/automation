using AutomationFramework.Helpers;
using AutomationFramework.Interfaces;
using OpenQA.Selenium;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomationFramework
{
    /// <summary>
    /// Implementation of <see cref="IExecution"/>
    /// </summary>
    public class Execution : IExecution
    {
        private IContainer container;

        /// <summary>
        /// Creates an instance of Execution
        /// </summary>
        /// <param name="container">Structuremap Container</param>
        public Execution(IContainer container)
        {
            this.container = container;
        }

        /// <summary>
        /// Uses the built elements <see cref="IBuilder"/> to execute the steps
        /// </summary>
        /// <param name="elements">WebElements used in execution</param>
        /// <param name="steps">Steps from the CSV</param>
        /// <returns>List of what actions executed properly</returns>
        public List<bool> Run(Dictionary<string, IWebElement> elements, Dictionary<string, string> steps)
        {
            Validators.IsArgumentNull(elements, steps);
            List<bool> results = new List<bool>();

            var actions = GroupActions(steps);
            bool outputBool;
            IExecutor executor = container.GetInstance<IExecutor>();

            foreach(var item in actions)
            {
                var methodInfo = executor.GetType().GetMethod(item[1]);

                var element = elements.ContainsKey(item[0]) ? elements[item[0]] : throw new NoSuchElementException("item[0]");
                object[] args = item.Count == 3 ? new Object[] { element, item[2] } : new object[] { element };

                var output = methodInfo.Invoke(executor, args);
                bool.TryParse(output.ToString(), out outputBool);

                results.Add(outputBool);
            }

            return results;
        }

        /// <summary>
        /// Uses an already existing PageObject/Factory to execute the steps
        /// </summary>
        /// <param name="instance">PageObject/Factory to use</param>
        /// <param name="steps">Steps from the CSV</param>
        /// <returns>List of what actions executed properly</returns
        public List<bool> Run(object instance, Dictionary<string, string> steps)
        {
            Validators.IsArgumentNull(instance);
            List<bool> results = new List<bool>();

            var actions = GroupActions(steps);
            bool outputBool;
            IExecutor execution = container.GetInstance<IExecutor>();

            foreach(var item in actions)
            {
                var type = execution.GetType();
                var propertyInfo = instance.GetType().GetProperty(item[0]);
                var element = propertyInfo.GetValue(instance);
                var methodInfo = execution.GetType().GetMethod(item[1]);

                object[] args = item.Count == 3 ? new object[] { element, item[2] } : new object[] { element };

               var output = methodInfo.Invoke(execution, args);
               bool.TryParse(output.ToString(), out outputBool);

                results.Add(outputBool);
            }

            return results;
        }

        /// <summary>
        /// Groups the steps into actions that can be executed
        /// </summary>
        /// <param name="steps">User defined steps</param>
        /// <returns>Returns the ordered steps (item, aciton, text)</returns>
        public List<List<string>> GroupActions(Dictionary<string, string> steps)
        {
            int counter = -1;
            List<List<string>> compiledList = new List<List<string>>();
            List<string> temporaryList = new List<string>();
            foreach(var item in steps)
            {
                int current;
                int.TryParse(Regex.Match(item.Key, @"\d+").Value, out current);

                if(current != counter)
                {
                    if(temporaryList.Count != 0)
                    {
                        compiledList.Add(temporaryList);
                    }
                    counter = current;
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        temporaryList = new List<string>();
                        temporaryList.Add(item.Value);
                    }
                } else
                {
                    if (!string.IsNullOrEmpty(item.Value))
                    {
                        temporaryList.Add(item.Value);
                    }
                }
            }
            if(temporaryList.Count != 0)
            {
                compiledList.Add(temporaryList);
            }
            return compiledList;
        }
    }
}
