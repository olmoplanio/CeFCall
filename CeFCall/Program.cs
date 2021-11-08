using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CeFCall
{
    //Copyright Paolo Olmino 2021
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
            bool isg = !options.Contains('p');
            if (isg)
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
                        return GetHelp();
                }
            }
            else
            {

                var pl = new Platform();
                int lpwdSysError = 0;
                int vRet = 0;
                switch (command)
                {
                    case "open":
                        CheckLen(arguments, 5);
                        vRet = pl.CEFOpen(Int32.Parse(arguments[0]), UInt32.Parse(arguments[1]), Byte.Parse(arguments[2]), Byte.Parse(arguments[3]), Byte.Parse(arguments[4]), Byte.Parse(arguments[5]), ref lpwdSysError);
                        return new string[] { vRet.ToString() };
                    case "write":
                        CheckLen(arguments, 0);
                        vRet = pl.CEFWrite(arguments[0], ref lpwdSysError);
                        return new string[] { vRet.ToString() };
                    case "read":
                        var sb1 = new StringBuilder();
                        int _ = 0;
                        vRet = pl.CEFRead(sb1, ref _, ref lpwdSysError);
                        return new string[] { vRet.ToString(), sb1.ToString() };
                    case "openeth":
                        CheckLen(arguments, 1);
                        vRet = pl.CEFOpenEth(arguments[0], int.Parse(arguments[1]), ref lpwdSysError);
                        return new string[] { vRet.ToString() };
                    case "close":
                        vRet = pl.CEFClose(ref lpwdSysError);
                        return new string[] { vRet.ToString() };
                    case "getversion":
                        var sb2 = new StringBuilder(256);
                        vRet = pl.CEFGetVersion(sb2, ref lpwdSysError);
                        return new string[] { vRet.ToString(), sb2.ToString() };
                    default:
                        return GetHelp();
                }
            }
        }

        private static void CheckLen(string[] arguments, int l)
        {
            if (arguments.Length < l + 1)
                throw new ArgumentException($"Arguments not provided: {l + 1} arguments required");
        }

        private string[] GetHelp()
        {
            return new string[] { "-1", "Syntax: CeFCall.exe [/tp] <command> [<arguments> ...]"};
        }
    }
}
