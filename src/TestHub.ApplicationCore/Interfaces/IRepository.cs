namespace TestHub.Core.Interfaces
{
    public interface IRepository<T>
    {
        T GetById(int id);
    }
}
