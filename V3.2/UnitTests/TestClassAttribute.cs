using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    internal class TestClassAttribute : Attribute
    {
        public static IEnumerable<Type> GetTestClasses(Assembly assembly)
        {
            List<Type> testClasses = new List<Type>();
            foreach (Type type in assembly.GetTypes())
            {
                object[] attributes = type.GetCustomAttributes(typeof(TestClassAttribute), true);
                if (attributes.Length > 0)
                {
                    testClasses.Add(type);
                }
            }

            return testClasses;
        }
    }
}

