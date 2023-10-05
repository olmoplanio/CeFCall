using com.github.olmoplanio.UnitTesting;
using System;

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Runner.Main(typeof(Program).Assembly);
            Console.Out.WriteLine("Press any key.");
            Console.In.Read();
        }
    }
}
