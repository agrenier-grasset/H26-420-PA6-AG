public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    bool Remove(int id);
    IReadOnlyList<T> GetAll();
}
