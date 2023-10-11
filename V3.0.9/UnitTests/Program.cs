using com.github.olmoplanio.UnitTesting;
using System;

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string testName = args.Length > 0 ? args[0] : null;
            Runner.Main(typeof(Program).Assembly, testName);
            Console.Out.WriteLine("Press any key.");
            Console.In.Read();
        }
    }
}
