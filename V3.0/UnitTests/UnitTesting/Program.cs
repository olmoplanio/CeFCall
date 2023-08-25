using System;


namespace Microsoft.VisualStudio.TestTools.UnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Running tests...");
            foreach(var c in TestClassAttribute.GetTestClasses(typeof(Program).Assembly))
            {
                Console.Out.WriteLine("# {0}", c.Name);
                object instance = Activator.CreateInstance(c);
                foreach (var m in TestMethodAttribute.GetTestMethods(c))
                {
                    Console.Out.WriteLine("## Starting {0}.{1}", c.Name, m.Name);
                    try
                    {
                        var ret = m.Invoke(instance, new object[0]);
                        Console.Out.WriteLine("## Done {0}.{1}: {2}", c.Name, m.Name, ret ?? "none");
                    }
                    catch(Exception ex)
                    {
                        Console.Out.WriteLine("## Failed {0}.{1}: {2}", c.Name, m.Name, ex.Message);
                    }
                    Console.Out.WriteLine();
                }
            }
            Console.Out.WriteLine("Press any key.");
            Console.In.Read();
        }
    }
}
