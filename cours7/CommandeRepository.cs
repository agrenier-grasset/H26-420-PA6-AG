using Microsoft.Data.SqlClient;

public class CommandeRepository
{
    private readonly string _connectionString;
    private readonly Stack<string> _requetesExecutees = new Stack<string>();

    public CommandeRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IReadOnlyCollection<string> RequetesExecutees => _requetesExecutees;

    public Queue<Commande> LireCommandesEnFile(int clientId)
    {
        Queue<Commande> file = new Queue<Commande>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            string sql = "SELECT Id, ClientId, Montant, Description, DateCommande FROM Commandes WHERE ClientId = @clientId";
            _requetesExecutees.Push(sql);

            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.Parameters.Add(new SqlParameter("@clientId", clientId));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        file.Enqueue(new Commande
                        {
                            Id = reader.GetInt32(0),
                            ClientId = reader.GetInt32(1),
                            Montant = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            DateCommande = reader.GetDateTime(4)
                        });
                    }
                }
            }
        }

        return file;
    }
}
