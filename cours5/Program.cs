using Microsoft.Data.SqlClient;

string connectionString = "Server=(localdb)\\mssqllocaldb;Database=MaBase;" +
    "Trusted_Connection=True;MultipleActiveResultSets=true";

try
{
    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
        sqlConnection.Open();
        Console.WriteLine("Connexion ouverte avec succès.");
    }
}
catch (SqlException ex)
{
    Console.WriteLine($"Erreur SQL : {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur générale : {ex.Message}");
}