using Microsoft.Data.SqlClient;

namespace cours7.RepositoryPattern;

public abstract class RepositoryBase<T> : IRepository<T>
{
    private readonly string _connectionString;

    protected RepositoryBase(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected TResult WithConnection<TResult>(Func<SqlConnection, TResult> action)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return action(connection);
    }

    protected void WithConnection(Action<SqlConnection> action)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        action(connection);
    }

    public abstract IEnumerable<T> GetAll();
    public abstract T? GetById(int id);
    public abstract int Add(T entity);
    public abstract bool Update(T entity);
    public abstract bool Delete(int id);
}
