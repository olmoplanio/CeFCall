using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    internal class TestMethodAttribute : Attribute
    {

        public static IEnumerable<MethodInfo> GetTestMethods(Type type)
        {
            List<MethodInfo> testMethods = new List<MethodInfo>();
            foreach (MethodInfo method in type.GetMethods())
            {
                object[] attributes = method.GetCustomAttributes(typeof(TestMethodAttribute), true);
                if (attributes.Length > 0)
                {
                    testMethods.Add(method);
                }
            }

            return testMethods;
        }
    }
}