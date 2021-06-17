using QuantumJobsViewer.Common;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs;
using System.Threading.Tasks;
using System;
using Azure.Storage.Blobs.Models;
using System.Linq;

namespace QuantumJobsViewer.Service
{
    public interface IJobOutputService
    {
        Task<IEnumerable<ContainerInfo>> GetOutputs();
    }

    public class JobOutputService : IJobOutputService
    {
        readonly BlobServiceClient _blobServiceClient;

        public JobOutputService(ISettings settings)
        {
            _blobServiceClient = new BlobServiceClient(settings["quantum-storage-constr"]);
        }

        public async Task<IEnumerable<ContainerInfo>> GetOutputs()
        {
            var pages =  _blobServiceClient.GetBlobContainersAsync();


            var names = new List<ContainerInfo>();
            await foreach(var container in pages)
            {
                names.Add(new ContainerInfo
                {
                    Name = container.Name,
                    LastModified = container.Properties.LastModified
                });
            }

            return names;
        }
    }
}