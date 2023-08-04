using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

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
        public IEnumerable<string> Run(string command, string[] arguments, char[] options)
        {
            if (options.Contains('v'))
            {
                return new string[] { "0", "V03.00" };
            }
            bool ack = options.Contains('k');
            bool is2 = options.Contains('2');
            bool isx = options.Contains('x');
            if (is2)
            {
                switch (command)
                {
                    case "getversion":
                        return new string[] { "0", UdpCaller.GetVersion() };
                    case "send":
                    case "exec":
                        var sfc = new UdpCaller(arguments[0], Int32.Parse(arguments[1]), ack);
                        CheckLen(arguments, 2);
                        var commands = arguments.Skip(2);
                        sfc.Send(commands);
                        return new string[] { "0", "" };
                    case "ping":
                        CheckLen(arguments, 0);
                        return new string[] { "0", "" + UdpCaller.Ping(arguments[0]) };
                    default:
                        Console.Out.WriteLine("Unknown command '{0}'", command);
                        return GetHelp();
                }
            }
            else if(isx)
            {
                switch (command)
                {
                    case "getversion":
                        return new string[] { "0", UdpCaller.GetVersion() };
                    case "send":
                    case "exec":
                        var sfc = new UdpCaller(arguments[0], Int32.Parse(arguments[1]), ack);
                        CheckLen(arguments, 2);
                        var commands = arguments.Skip(2);
                        sfc.Send(commands);
                        return new string[] { "0", "" };
                    case "ping":
                        CheckLen(arguments, 0);
                        return new string[] { "0", "" + UdpCaller.Ping(arguments[0]) };
                    default:
                        Console.Out.WriteLine("Unknown command '{0}'", command);
                        return GetHelp();
                }
            }
            else
            {
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
                        string[] commands = arguments.Skip(2).ToArray();
                        return gw.Exec(arguments[0], Int32.Parse(arguments[1]), commands);
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
