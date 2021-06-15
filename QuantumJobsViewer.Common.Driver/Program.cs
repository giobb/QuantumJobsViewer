using System;

namespace QuantumJobsViewer.Common.Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var setting = new QuantumJobsViewer.Common.Settings();
            var hello = setting[""];
        }
    }
}
