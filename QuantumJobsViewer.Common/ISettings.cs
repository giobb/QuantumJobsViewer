using Azure.Core;
using Azure.Security.KeyVault.Secrets;
using System;
using Azure.Identity;

namespace QuantumJobsViewer.Common
{
    public interface ISettings
    {
        string this[string key] { get; }
    }

    public class Settings : ISettings
    {
        readonly SecretClient _sectetClient;
        public Settings()
        {
            var options = new DefaultAzureCredentialOptions
            {
                VisualStudioTenantId = "e0f08fd5-db36-486c-abf8-b510fd977634",
            };
            _sectetClient = new SecretClient(new Uri("https://gioskv.vault.azure.net/"), new DefaultAzureCredential(options));
        }

        public string this[string key] => _sectetClient.GetSecret(key).Value.Value;
    }
}
