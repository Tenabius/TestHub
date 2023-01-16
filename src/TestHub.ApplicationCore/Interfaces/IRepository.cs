namespace TestHub.ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
    }
}
