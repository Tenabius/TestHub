using Google.Cloud.SecretManager.V1;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Services
{
    public class GoogleSecretManager : IKeyVaultManager
    {
        private readonly string _projectId;

        public GoogleSecretManager(IConfiguration configuration)
        {
            _projectId = configuration.GetValue<string>("GoogleSecretManage:ProjectId")!;
        }

        public string GetSecret(string secretName)
        {
            SecretManagerServiceClient client = SecretManagerServiceClient.Create();
            SecretVersionName secretVersionName = new(_projectId, secretName.Replace(":", "--"), "latest");
            AccessSecretVersionResponse result = client.AccessSecretVersion(secretVersionName);
            return result.Payload.Data.ToStringUtf8();
        }
    }
}
