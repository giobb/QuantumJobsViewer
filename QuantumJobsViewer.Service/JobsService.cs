using System;
using System.Collections.Generic;

namespace QuantumJobsViewer.Service
{
    public interface IJobsService
    {
        IEnumerable<string> GetResults(DateTime? from, DateTime? to);
    }

    public class JobsService : IJobsService
    {
        readonly IBlobService _blobService;

        public IEnumerable<string> GetResults(DateTime? from, DateTime? to)
        {
            throw new NotImplementedException();
        }
    }
}
