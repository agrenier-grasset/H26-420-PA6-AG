public class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item)
    {
        _items.Add(item);
    }

    public bool Remove(int id)
    {
        T? item = _items.Find(x => x.Id == id);
        if (item is null)
        {
            return false;
        }

        return _items.Remove(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }
}
