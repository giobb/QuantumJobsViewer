using QuantumJobsViewer.Common;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Blobs;
using System.Threading.Tasks;

namespace QuantumJobsViewer.Service
{
    public interface IBlobService
    {
        Task<IEnumerable<ContainerInfo>> GetContainerNamesAsync();
    }

    public class BlobService : IBlobService
    {
        readonly BlobServiceClient _blobServiceClient;

        public BlobService(ISettings settings)
        {
            _blobServiceClient = new BlobServiceClient(settings["quantum-storage-constr"]);
        }

        public async Task<IEnumerable<ContainerInfo>> GetContainerNamesAsync()
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