using QuantumJobsViewer.Common;
using System;
using System.Linq;

namespace QuantumJobsViewer.Service.Driver
{
    public class Program
    {
        static void Main(string[] args)
        {
            var blobService = new BlobService(new Settings());
            var names = blobService.GetContainerNamesAsync().Result;
            foreach (var n in names.Take(50).OrderByDescending(o=>o.LastModified))
            {
                Console.WriteLine($"{n.Name} - {n.LastModified}");
            }
        }
    }
}
