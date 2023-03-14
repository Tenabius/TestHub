namespace TestHub.Infrastructure.Interfaces
{
    public interface IKeyVaultManager
    {
        string GetSecret(string secretName);
    }
}
