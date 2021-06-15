using QuantumJobsViewer.Model;
using System;
using System.Collections.Generic;

namespace QuantumJobsViewer.Abstraction
{
    public interface IJobsService
    {
        IEnumerable<JobResult> GetResults(DateTime? from, DateTime? to);
    }
}
