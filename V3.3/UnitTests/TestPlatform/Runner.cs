using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace com.github.olmoplanio.UnitTesting
{
    public partial class Runner
    {

        readonly Assembly assembly;
        readonly string testName;

        readonly static private List<string> results = new List<string> ();

        public Runner(Assembly assembly, string testName)
        {
            this.assembly = assembly;
            this.testName = testName;
        }
        public Runner(Assembly assembly)
        {
            this.assembly = assembly;
            this.testName = null;
        }

        private static void AddResult(string result)
        {
            results.Add(result);
        }

        private static void WriteLog()
        {
            Console.Out.WriteLine();
        }
        private static void WriteLog(string message, params object[] args)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Out.WriteLine(message, args);
            Console.ForegroundColor = saveColor;
        }
        private static void WriteErr(string message, params object[] args)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Out.WriteLine(message, args);
            Console.ForegroundColor = saveColor;
        }

        public static void Main(Assembly assembly, string testName)
        {
            if (string.IsNullOrEmpty(testName))
            {
                WriteLog("Running tests...");
            }
            else
            {
                WriteLog("Running test '{0}'...", testName);
            }

            var runner = new Runner(assembly, testName);
            runner.Run();
            WriteLog("Done.", testName);
        }

        public void Run()
        {
            foreach (var mi in TestItems())
            {
                mi.Run();
            }
        }
        
        public void Start()
        {
            var tz = new List<Thread>();
            foreach (var mi in TestItems())
            {
                var t = new Thread(mi.Run);
                t.Start();
                tz.Add(t);
            }
            foreach (var t in tz)
            {
                t.Join();
            }
            foreach(var r in results)
            {
                Console.Out.WriteLine(r);
            }
        }

        public IEnumerable<TestItem> TestItems()
        {
            foreach(var c in TestClassAttribute.GetTestClasses(assembly))
            {
                if (string.IsNullOrEmpty(testName) || testName.Equals(c.Name) || testName.StartsWith(c.Name + "."))
                {
                    object instance = Activator.CreateInstance(c);
                    foreach (var m in TestMethodAttribute.GetTestMethods(c))
                    {
                        if (string.IsNullOrEmpty(testName) || testName.Equals(c.Name) || testName.Equals(c.Name + "." + m.Name))
                        {
                            yield return new TestItem(m, instance);
                        }
                    }
                }
            }
        }

        
    }
}
