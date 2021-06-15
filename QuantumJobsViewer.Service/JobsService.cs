using QuantumJobsViewer.Abstraction;
using QuantumJobsViewer.Model;
using System;
using System.Collections.Generic;

namespace QuantumJobsViewer.Service
{
    public class JobsService : IJobsService
    {
        readonly Abstraction.IBlobService _blobService;

        public IEnumerable<JobResult> GetResults(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }
    }
}
