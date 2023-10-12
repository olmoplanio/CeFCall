using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace com.github.olmoplanio.UnitTesting
{
    public static class Runner
    {
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

        public static void Main(System.Reflection.Assembly assembly, string testName = null)
        {
            if (string.IsNullOrEmpty(testName))
            {
                WriteLog("Running tests...");
            }
            else
            {
                WriteLog("Running test '{0}'...", testName);
            }
            foreach(var c in TestClassAttribute.GetTestClasses(assembly))
            {
                if (string.IsNullOrEmpty(testName) || testName.Equals(c.Name) || testName.StartsWith(c.Name + "."))
                {
                    WriteLog("# {0}", c.Name);
                    WriteLog();
                    object instance = Activator.CreateInstance(c);
                    foreach (var m in TestMethodAttribute.GetTestMethods(c))
                    {
                        if (string.IsNullOrEmpty(testName) || testName.Equals(c.Name) || testName.Equals(c.Name + "." + m.Name))
                        {
                            WriteLog("## Test Method {0}.{1}", c.Name, m.Name);
                            WriteLog();
                            WriteLog("Starting Method {0}.{1}", c.Name, m.Name);
                            try
                            {
                                var ret = m.Invoke(instance, new object[0]);
                                WriteLog("Done {0}.{1}: {2}", c.Name, m.Name, ret ?? (object)"OK");
                            }
                            catch(System.Reflection.TargetInvocationException tix)
                            {
                                var x = tix.InnerException;

                                if (x is UnitTestAssertException)
                                {
                                    WriteErr("Failed {0}.{1}: {2}", c.Name, m.Name, x.Message);
                                }
                                else
                                {
                                    WriteErr("Failed {0}.{1}: {2}", c.Name, m.Name, x);
                                }
                            }
                            catch (Exception ex)
                            {
                                WriteErr("Failed {0}.{1}: {2}", c.Name, m.Name, ex);
                            }
                            WriteLog();
                        }
                    }
                }
            }
        }
    }
}
