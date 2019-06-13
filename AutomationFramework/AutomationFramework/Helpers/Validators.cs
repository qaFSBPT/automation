using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Helpers
{
    public static class Validators
    {
        /// <summary>
        /// Checks whether the objects are null
        /// </summary>
        /// <param name="objs">Objects to be checked</param>
        public static void IsArgumentNull(params object[] objs)
        {
            foreach (var item in objs)
            {
                if (item == null)
                {
                    throw new ArgumentNullException();
                }
            }
        }

        /// <summary>
        /// Check whether the strings are null/empty
        /// </summary>
        /// <param name="objs">Strings to be checked</param>

        public static void IsArgumentEmpty(params string[] objs)
        {
            foreach(var item in objs)
            {
                if (string.IsNullOrEmpty(item))
                {
                    throw (item == null ? new ArgumentNullException() : new ArgumentException());
                }
            }
        }
    }
}
