using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace com.github.olmoplanio.CeFCall
{
    //Copyright Paolo Olmino 2021-2023
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            IList<string> arguments = new List<string>();
            string options = String.Empty;

            bool commandWasRead = false;
            foreach (var arg in args)
            {
                if (!commandWasRead)
                {
                    string a = arg.ToLower();
                    if (a.StartsWith("/"))
                    {
                        options += a.Substring(1);
                    }
                    else
                    {
                        command = a;
                        commandWasRead = true;
                    }
                }
                else
                {
                    arguments.Add(arg);
                }
            }

            var call = new Program();
            var ret = call.Run(command, arguments.ToArray(), options.ToCharArray());

            foreach (var s in ret)
            {
                Console.Out.WriteLine(s);
            }
            if (options.Contains('t'))
            {
                Console.In.ReadLine();
            }

        }
        public string[] Run(string command, string[] parameters, char[] options)
        {
            if (options.Contains('v'))
            {
                return new string[] { "0", "V03.02" };
            }

            ICommandMode commandMode;

            if (options.Contains('c'))
            {
                commandMode = new CustomMode();
            }
            else if (options.Contains('d'))
            {
                commandMode = new CustomDllMode();
            }
            else
            {
                commandMode = new CustomDllMode();
            }

            return Run(commandMode, command, parameters, options);
        }

        private string[] Run(ICommandMode commandMode, string command, string[] arguments, char[] options)
        {
            switch (command)
            {
                case "getversion":
                    return new string[] { commandMode.Version };
                case "exec":
                    CheckLen(arguments, 2);
                    string[] commands0 = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                    var res = commandMode.Execute(arguments[0], Int32.Parse(arguments[1]), commands0);
                    return new string[] { res.ErrorCode.ToString(), res.Message};
                case "ping":
                    CheckLen(arguments, 2);
                    return new string[] { commandMode.Ping(arguments[0], Int32.Parse(arguments[1])) };
                default:
                    Console.Out.WriteLine("Unknown command '{0}'", command);
                    return GetHelp();
            }
        }

        private static void CheckLen(string[] arguments, int l)
        {
            if (arguments.Length < l + 1)
                throw new ArgumentException(String.Format("Arguments not provided: {0} arguments required", l + 1));
        }

        private string[] GetHelp()
        {
            string strResourceName = "README.md";

            Assembly asm = Assembly.GetExecutingAssembly();
            using (Stream rsrcStream = asm.GetManifestResourceStream("com.github.olmoplanio.CeFCall." + strResourceName))
            {
                using (StreamReader sRdr = new StreamReader(rsrcStream))
                {
                    //For instance, gets it as text
                    return sRdr.ReadToEnd().Split(new char[] { '\n' });
                }
            }
        }
    }
}
