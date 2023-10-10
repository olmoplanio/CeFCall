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
                System.Threading.Thread.Sleep(5000);
            }

        }
        public IEnumerable<string> Run(string command, string[] arguments, char[] options)
        {
            if (options.Contains('v'))
            {
                return new string[] { "0", "V03.01" };
            }
            char mode = 'd';

            if (options.Contains('x'))
            {
                mode = 'x';
            }
            else if (options.Contains('c'))
            {
                mode = 'c';
            }
            else if (options.Contains('d'))
            {
                mode = 'd';
            }
            else if (options.Contains('b'))
            {
                mode = 'b';
            }


            string ip;
            int port;

            switch (mode)
            {
                case 'c':
                    var caller = new CustomClient();
                    CheckLen(arguments, 2);
                    ip = arguments[0];
                    port = Int32.Parse(arguments[1]);
                    string[] commands = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                    string ret1 = caller.Exec(ip, port, String.Join(" ", commands.ToArray()));


                    switch (command)
                    {
                        case "call":
                            return new string[] { ret1 };
                        case "exec":
                            return new string[] { "0", ret1 };
                        case "ping":
                            CheckLen(arguments, 0);
                            return new string[] { "0", "pong" };
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }
                case 'x':

                    var caller2 = new SfcCaller();

                    switch (command)
                    {
                        case "getversion":
                            return new string[] { "0", caller2.GetVersion() };
                        case "send":
                        case "exec":
                            CheckLen(arguments, 2);
                            ip = arguments[0];
                            port = Int32.Parse(arguments[1]);
                            var commands2 = arguments.Skip(2);
                            caller2.Send(ip, port, commands2);
                            return new string[] { "0", "" };
                        case "ping":
                            CheckLen(arguments, 0);
                            return new string[] { "0", "" + caller2.Ping(arguments[0]) };
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }
                case 'd':
                    var gw = new Gateway();
                    switch (command)
                    {
                        case "getversion":
                            return gw.GetVersion();
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
                            CheckLen(arguments, 0);
                            return gw.Ping(arguments[0]);
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }
                default:
                    var caller3 = new BaseClient();
                    CheckLen(arguments, 2);
                    ip = arguments[0];
                    port = Int32.Parse(arguments[1]);
                    string[] commands3 = arguments.Skip(2).Select(x => x.Replace('^', '"')).ToArray();
                    string ret3 = caller3.Exec(ip, port, String.Join(" ", commands3.ToArray()));


                    switch (command)
                    {
                        case "call":
                            return new string[] { ret3 };
                        case "exec":
                            return new string[] { "0", ret3 };
                        case "ping":
                            CheckLen(arguments, 0);
                            return new string[] { "0", "pong" };
                        default:
                            Console.Out.WriteLine("Unknown command '{0}'", command);
                            return GetHelp();
                    }

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
