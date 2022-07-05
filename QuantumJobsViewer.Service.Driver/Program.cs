using QuantumJobsViewer.Common;
using System;
using System.Linq;

namespace QuantumJobsViewer.Service.Driver
{
    public class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new();
            var blobConStr = settings["quantum-storage-constr"]);
            var blobService = new JobOutputService(blobConStr);
            var names = blobService.GetOutputs().Result;
            foreach (var n in names.Take(50).OrderByDescending(o=>o.LastModified))
            {
                Console.WriteLine($"{n.Name} - {n.LastModified}");
            }
        }
    }
}
