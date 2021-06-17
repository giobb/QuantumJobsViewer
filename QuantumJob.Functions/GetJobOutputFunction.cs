using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QuantumJobsViewer.Common;
using QuantumJobsViewer.Service;
using System.Linq;
using System.Web.Http;

namespace QuantumJob.Functions
{
    public static class GetJobOutputFunction
    {
        [FunctionName("GetJobOutputs")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            try
            {

                JobOutputService blobService = new(new Settings());
                var jobs = await blobService.GetOutputs();

                log.LogInformation($"Number of outputs retrieved: {jobs.Count()}");
                

                return new OkObjectResult(jobs);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new ExceptionResult(ex, false);
            }
            
        }
    }
}
