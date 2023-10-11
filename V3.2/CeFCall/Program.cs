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

            bool mode = false;
            foreach (var arg in args)
            {
                if (!mode)
                {
                    string a = arg.ToLower();
                    if (a.StartsWith("/"))
                    {
                        options += a.Substring(1);
                    }
                    else
                    {
                        command = a;
                        mode = true;
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
        public string[] Run(string command, string[] arguments, char[] options)
        {
            if (options.Contains('v'))
            {
                return new string[] { "0", "V03.02" };
            }
            char mode = 'd';

            if (options.Contains('c'))
            {
                mode = 'c';
            }
            else if (options.Contains('d'))
            {
                mode = 'd';
            }


            string ip;
            int port;

            switch (mode)
            {
                case 'c':
                    var caller = new CustomClient();


                    switch (command)
                    {
                        case "call":
                            CheckLen(arguments, 2);
                            ip = arguments[0];
                            port = Int32.Parse(arguments[1]);
                            var cmds = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                            return new string[] { caller.Exec(ip, port, cmds).Message };
                        case "exec":
                            CheckLen(arguments, 2);
                            ip = arguments[0];
                            port = Int32.Parse(arguments[1]);
                            var commands = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                            return caller.Exec(ip, port, commands).ToArray();
                        case "ping":
                            CheckLen(arguments, 1);
                            ip = arguments[0];
                            port = Int32.Parse(arguments[1]);
                            return caller.Exec(ip, port, "1009").ToArray();
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }
                case 'd':
                    var gw = new Gateway();
                    switch (command)
                    {
                        case "getversion":
                            return new string[] { gw.GetVersion() };
                        case "sendcommand":
                            CheckLen(arguments, 0);
                            return gw.Send(arguments[0]);
                        case "read":
                            return gw.Read();
                        case "exec":
                            CheckLen(arguments, 2);
                            string[] commands0 = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                            return gw.Exec(arguments[0], Int32.Parse(arguments[1]), commands0);
                        case "openeth":
                            CheckLen(arguments, 1);
                            return gw.OpenEth(arguments[0], Int32.Parse(arguments[1]));
                        case "close":
                            return gw.Close();
                        case "ping":
                            CheckLen(arguments, 2);
                            return gw.OpenEth(arguments[0], Int32.Parse(arguments[1]));
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }
                default:
                    Console.Out.WriteLine("Undefined client '{0}'", mode);
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
