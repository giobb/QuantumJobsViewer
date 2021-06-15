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
            _sectetClient = new SecretClient(new Uri("https://gioskv.vault.azure.net/"), new InteractiveBrowserCredential());
        }

        public string this[string key] => _sectetClient.GetSecret("MySPSecret").Value.Value;
    }
}
