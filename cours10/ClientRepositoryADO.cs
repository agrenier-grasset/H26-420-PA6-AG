using Microsoft.Data.SqlClient;

namespace cours10;

public class ClientRepositoryADO : IClientRepository
{
    private readonly string nomBaseDonnees = "Exercices_Cours10";
    private readonly string _connectionString;
    private bool _initialized = false;

    public ClientRepositoryADO()
    {
        _connectionString = $"Server=(localdb)\\mssqllocaldb;Database={nomBaseDonnees};" +
            "Trusted_Connection=True;MultipleActiveResultSets=true";
    }

    private void EnsureInitialized()
    {
        if (_initialized) return;

        string masterConnectionString = "Server=(localdb)\\mssqllocaldb;Database=master;Trusted_Connection=True;";
        using (SqlConnection conn = new SqlConnection(masterConnectionString))
        {
            conn.Open();
            using SqlCommand cmd = new SqlCommand(
                $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{nomBaseDonnees}') " +
                $"CREATE DATABASE [{nomBaseDonnees}]", conn);
            cmd.ExecuteNonQuery();
        }

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using SqlCommand cmd = new SqlCommand(@"
                IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clients')
                CREATE TABLE Clients (
                    Id    INT           PRIMARY KEY IDENTITY(1,1),
                    Nom   NVARCHAR(100) NOT NULL,
                    Email NVARCHAR(200) NOT NULL
                )", conn);
            cmd.ExecuteNonQuery();
        }

        _initialized = true;
    }

    public List<Client> GetAll()
    {
        EnsureInitialized();
        var clients = new List<Client>();
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
        using SqlCommand cmd = new SqlCommand("SELECT Id, Nom, Email FROM Clients ORDER BY Nom", conn);
        using SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            clients.Add(new Client
            {
                Id    = reader.GetInt32(0),
                Nom   = reader.GetString(1),
                Email = reader.GetString(2)
            });
        }
        return clients;
    }

    public Client? GetById(int id)
    {
        EnsureInitialized();
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
        using SqlCommand cmd = new SqlCommand(
            "SELECT Id, Nom, Email FROM Clients WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        using SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            return new Client
            {
                Id    = reader.GetInt32(0),
                Nom   = reader.GetString(1),
                Email = reader.GetString(2)
            };
        }
        return null;
    }

    public void Add(Client c)
    {
        EnsureInitialized();
        using SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
        using SqlCommand cmd = new SqlCommand(
            "INSERT INTO Clients (Nom, Email) VALUES (@nom, @email)", conn);
        cmd.Parameters.AddWithValue("@nom", c.Nom);
        cmd.Parameters.AddWithValue("@email", c.Email);
        cmd.ExecuteNonQuery();
    }
}
