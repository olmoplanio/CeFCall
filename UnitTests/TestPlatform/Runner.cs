using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace com.github.olmoplanio.UnitTesting
{
    public static class Runner
    {
        public static void Main(System.Reflection.Assembly assembly)
        {
            Console.Out.WriteLine("Running tests...");
            foreach(var c in TestClassAttribute.GetTestClasses(assembly))
            {
                Console.Out.WriteLine("# {0}", c.Name);
                Console.Out.WriteLine();
                object instance = Activator.CreateInstance(c);
                foreach (var m in TestMethodAttribute.GetTestMethods(c))
                {
                    Console.Out.WriteLine("## Starting {0}.{1}", c.Name, m.Name);
                    Console.Out.WriteLine();
                    try
                    {
                        var ret = m.Invoke(instance, new object[0]);
                        Console.Out.WriteLine();
                        Console.Out.WriteLine("Done {0}.{1}: {2}", c.Name, m.Name, ret ?? "none");
                    }
                    catch(Exception ex)
                    {
                        Console.Out.WriteLine();
                        Console.Out.WriteLine("Failed {0}.{1}: {2}", c.Name, m.Name, ex.Message);
                    }
                    Console.Out.WriteLine();
                }
            }
        }
    }
}
