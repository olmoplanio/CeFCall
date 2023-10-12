using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace com.github.olmoplanio.UnitTesting
{
    public partial class Runner
    {
        public class TestItem
        {
            private MethodInfo methodInfo;
            private object instance;

            public MethodInfo MethodInfo { get => methodInfo; private set => methodInfo = value; }
            public object Instance { get => instance; private set => instance = value; }

            internal TestItem(MethodInfo methodInfo, object instance)
            {
                MethodInfo = methodInfo;
                Instance = instance;
            }

            public void Run()
            {
                Type type = methodInfo.DeclaringType;
                WriteLog("## Test Method {0}.{1}", type.Name, methodInfo.Name);
                WriteLog();
                WriteLog("Starting Method {0}.{1}", type.Name, methodInfo.Name);
                try
                {
                    methodInfo.Invoke(instance, new object[0]);
                    WriteLog("Done {0}.{1}: {2}", type.Name, methodInfo.Name, "OK");
                    WriteLog();
                    AddResult($"{type.Name}.{methodInfo.Name}: Succeded");
                }
                catch (System.Reflection.TargetInvocationException tix)
                {
                    var x = tix.InnerException;

                    if (x is UnitTestAssertException)
                    {
                        WriteErr("Failed {0}.{1}: {2}", type.Name, methodInfo.Name, x.Message);
                        WriteLog();
                        AddResult($"{type.Name}.{methodInfo.Name}: Failed: {x.Message}");
                    }
                    else
                    {
                        WriteErr("Failed {0}.{1}: {2}", type.Name, methodInfo.Name, x);
                        WriteLog();
                        AddResult($"{type.Name}.{methodInfo.Name}: Failed: {x.Message}");
                    }
                }
                catch (Exception ex)
                {
                    WriteErr("Failed {0}.{1}: {2}", type.Name, methodInfo.Name, ex);
                    WriteLog();
                    AddResult($"{type.Name}.{methodInfo.Name}: Failed: {ex.Message}");
                }
            }
        }

        
    }
}
