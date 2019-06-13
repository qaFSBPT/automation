using OpenQA.Selenium;
using System;

namespace AutomationFramework.Helpers
{
    public static class InstanceCreator
    {
        /// <summary>
        /// Creates an instance of an already existing PageFactory from the CSV
        /// </summary>
        /// <param name="instanceName">Instance name to create</param>
        /// <param name="driver">Web driver to be passed into</param>
        /// <returns>PageFactory instance</returns>
        public static object Create(string instanceName, IWebDriver driver)
        {
            var type = Type.GetType(instanceName);
            if (type == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    type = asm.GetType(instanceName);
                    if (type != null)
                    {
                        return Activator.CreateInstance(type, new object[] { driver });

                    }
                }
            }
            return type == null ? null : Activator.CreateInstance(type, new object[] { driver });
        }
    }
}
