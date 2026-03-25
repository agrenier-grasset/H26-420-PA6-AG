using Microsoft.Data.SqlClient;
using System.Data;

namespace cours6
{
    public class DataRepository
    {
        private readonly string _connectionString;

        public DataRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // ===== CLIENTS CRUD =====
        public DataTable GetAllClients()
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Nom, Email, Solde FROM Clients ORDER BY Nom", connection))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public bool AddClient(string nom, string email, decimal solde)
        {
            ValidateClientInput(nom, email);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Clients (Nom, Email, Solde) VALUES (@nom, @email, @solde)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@solde", solde);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateClient(int id, string nom, string email, decimal solde)
        {
            ValidateClientInput(nom, email);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Clients SET Nom = @nom, Email = @email, Solde = @solde WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@solde", solde);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteClient(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Supprimer d'abord les commandes du client
                        string deleteCommandesQuery = "DELETE FROM Commandes WHERE ClientId = @id";
                        using (SqlCommand deleteCommandesCommand = new SqlCommand(deleteCommandesQuery, connection, transaction))
                        {
                            deleteCommandesCommand.Parameters.AddWithValue("@id", id);
                            deleteCommandesCommand.ExecuteNonQuery();
                        }

                        // Ensuite supprimer le client
                        string deleteClientQuery = "DELETE FROM Clients WHERE Id = @id";
                        using (SqlCommand deleteClientCommand = new SqlCommand(deleteClientQuery, connection, transaction))
                        {
                            deleteClientCommand.Parameters.AddWithValue("@id", id);
                            int result = deleteClientCommand.ExecuteNonQuery();
                            transaction.Commit();
                            return result > 0;
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void ValidateClientInput(string nom, string email)
        {
            if (string.IsNullOrWhiteSpace(nom))
                throw new ArgumentException("Le nom ne peut pas être vide.");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("L'email ne peut pas être vide.");

            if (!email.Contains("@"))
                throw new ArgumentException("L'email doit être valide.");

            if (nom.Length > 100)
                throw new ArgumentException("Le nom ne peut pas dépasser 100 caractères.");

            if (email.Length > 100)
                throw new ArgumentException("L'email ne peut pas dépasser 100 caractères.");
        }

        // ===== COMMANDES CRUD =====
        public DataTable GetCommandesByClientId(int clientId)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT Id, ClientId, Montant, Description, DateCommande FROM Commandes WHERE ClientId = @clientId ORDER BY DateCommande DESC";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@clientId", clientId);
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public bool AddCommande(int clientId, decimal montant, string description)
        {
            ValidateCommandeInput(montant, description);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Ajouter la commande
                        string insertQuery = "INSERT INTO Commandes (ClientId, Montant, Description, DateCommande) VALUES (@clientId, @montant, @description, GETDATE())";
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                        {
                            insertCommand.Parameters.AddWithValue("@clientId", clientId);
                            insertCommand.Parameters.AddWithValue("@montant", montant);
                            insertCommand.Parameters.AddWithValue("@description", description);
                            insertCommand.ExecuteNonQuery();
                        }

                        // Mettre à jour le solde du client
                        string updateSoldeQuery = "UPDATE Clients SET Solde = Solde - @montant WHERE Id = @clientId";
                        using (SqlCommand updateSoldeCommand = new SqlCommand(updateSoldeQuery, connection, transaction))
                        {
                            updateSoldeCommand.Parameters.AddWithValue("@montant", montant);
                            updateSoldeCommand.Parameters.AddWithValue("@clientId", clientId);
                            updateSoldeCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool UpdateCommande(int id, decimal montant, string description)
        {
            ValidateCommandeInput(montant, description);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Commandes SET Montant = @montant, Description = @description WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@montant", montant);
                    command.Parameters.AddWithValue("@description", description);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCommande(int id, int clientId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Récupérer le montant de la commande
                        string selectQuery = "SELECT Montant FROM Commandes WHERE Id = @id";
                        decimal montant = 0;
                        using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection, transaction))
                        {
                            selectCommand.Parameters.AddWithValue("@id", id);
                            object? result = selectCommand.ExecuteScalar();
                            if (result != null)
                                montant = (decimal)result;
                        }

                        // Supprimer la commande
                        string deleteQuery = "DELETE FROM Commandes WHERE Id = @id";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection, transaction))
                        {
                            deleteCommand.Parameters.AddWithValue("@id", id);
                            deleteCommand.ExecuteNonQuery();
                        }

                        // Restaurer le solde du client
                        string updateSoldeQuery = "UPDATE Clients SET Solde = Solde + @montant WHERE Id = @clientId";
                        using (SqlCommand updateSoldeCommand = new SqlCommand(updateSoldeQuery, connection, transaction))
                        {
                            updateSoldeCommand.Parameters.AddWithValue("@montant", montant);
                            updateSoldeCommand.Parameters.AddWithValue("@clientId", clientId);
                            updateSoldeCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private void ValidateCommandeInput(decimal montant, string description)
        {
            if (montant <= 0)
                throw new ArgumentException("Le montant doit être supérieur à 0.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("La description ne peut pas être vide.");

            if (description.Length > 200)
                throw new ArgumentException("La description ne peut pas dépasser 200 caractères.");
        }

        public decimal GetClientBalance(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Solde FROM Clients WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", clientId);
                    object? result = command.ExecuteScalar();
                    return result != null ? (decimal)result : 0;
                }
            }
        }
    }
}
