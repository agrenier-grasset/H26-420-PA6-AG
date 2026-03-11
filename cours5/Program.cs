using Microsoft.Data.SqlClient;

string nomBaseDonnees = "Exercices_Cours5";

string connectionString = $"Server=(localdb)\\mssqllocaldb;Database={nomBaseDonnees};" +
    "Trusted_Connection=True;MultipleActiveResultSets=true";

string masterConnectionString = "Server=(localdb)\\mssqllocaldb;Database=master;" +
    "Trusted_Connection=True;";

InitialiserBaseDeDonnees();

bool continuer = true;

while (continuer)
{
    Console.WriteLine("\n=== MENU EXERCICES ADO.NET ===");
    Console.WriteLine("1. Exercice 1 - Connexion à la base");
    Console.WriteLine("2. Exercice 2 - Lecture des données");
    Console.WriteLine("3. Exercice 3 - Insertion de données");
    Console.WriteLine("4. Exercice 4 - Mise à jour de données");
    Console.WriteLine("5. Exercice 5 - Suppression de données");
    Console.WriteLine("0. Quitter");
    Console.Write("\nChoisissez une option : ");

    string? choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            Exercice1();
            break;
        case "2":
            Exercice2();
            break;
        case "3":
            Exercice3();
            break;
        case "4":
            Exercice4();
            break;
        case "5":
            Exercice5();
            break;
        case "0":
            continuer = false;
            Console.WriteLine("Au revoir!");
            break;
        default:
            Console.WriteLine("Option invalide!");
            break;
    }
}

void InitialiserBaseDeDonnees()
{
    Console.WriteLine("=== Initialisation de la base de données ===");

    try
    {
        using (SqlConnection connection = new SqlConnection(masterConnectionString))
        {
            connection.Open();

            string checkDbQuery = $"SELECT database_id FROM sys.databases WHERE name = '{nomBaseDonnees}'";
            using (SqlCommand checkCommand = new SqlCommand(checkDbQuery, connection))
            {
                object? result = checkCommand.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine($"Création de la base de données '{nomBaseDonnees}'...");
                    string createDbQuery = $"CREATE DATABASE {nomBaseDonnees}";
                    using (SqlCommand createCommand = new SqlCommand(createDbQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine($"Base de données '{nomBaseDonnees}' créée avec succès!");
                    }
                }
                else
                {
                    Console.WriteLine($"La base de données '{nomBaseDonnees}' existe déjà.");
                }
            }
        }

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string checkTableQuery = "SELECT OBJECT_ID('Clients', 'U')";

            using (SqlCommand checkCommand = new SqlCommand(checkTableQuery, connection))
            {
                object? result = checkCommand.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    Console.WriteLine("Création de la table 'Clients'...");
                    string createTableQuery = @"
                        CREATE TABLE Clients (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Nom NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(100) NOT NULL
                        )";

                    using (SqlCommand createCommand = new SqlCommand(createTableQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine("Table 'Clients' créée avec succès!");
                    }

                    Console.WriteLine("Insertion de données d'exemple...");
                    string insertDataQuery = @"
                        INSERT INTO Clients (Nom, Email) VALUES 
                        ('Jean Dupont', 'jean.dupont@email.com'),
                        ('Marie Martin', 'marie.martin@email.com'),
                        ('Pierre Durand', 'pierre.durand@email.com')";

                    using (SqlCommand insertCommand = new SqlCommand(insertDataQuery, connection))
                    {
                        int rowsInserted = insertCommand.ExecuteNonQuery();
                        Console.WriteLine($"{rowsInserted} clients d'exemple ajoutés!");
                    }
                }
                else
                {
                    Console.WriteLine("La table 'Clients' existe déjà.");
                }
            }
        }

        Console.WriteLine("Initialisation terminée!\n");
    }
    catch (SqlException ex)
    {
        Console.WriteLine($"Erreur SQL lors de l'initialisation : {ex.Message}");
        Console.WriteLine("Le programme va continuer mais certaines fonctionnalités peuvent ne pas fonctionner.\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur générale lors de l'initialisation : {ex.Message}\n");
    }
}

//• Exercice 1 – Connexion à la base
//• Objectif : Vérifier la connexion à SQL Server depuis C#.
//• Énoncé :
//• Créer une base MaBase dans SSMS;
//• Écrire un programme C# qui ouvrir une connexion et afficher "Connexion réussie" si tout fonctionne.
void Exercice1()
{
    Console.WriteLine("\n--- Exercice 1 : Connexion à la base ---");
    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            Console.WriteLine("Connexion réussie");
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
}

//• Exercice 2 – Lecture des données
//• Objectif : Lire et afficher des données avec SqlDataReader.
//• Énoncé :
//• Dans SSMS, créer une table Clients avec Id, Nom, Email et insérer quelques lignes;
//• Écrire un programme C# qui lit et afficher tous les clients.
void Exercice2()
{
    Console.WriteLine("\n--- Exercice 2 : Lecture des données ---");
    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();

            string query = "SELECT Id, Nom, Email FROM Clients";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nListe des clients :");
                    Console.WriteLine("ID\tNom\t\tEmail");
                    Console.WriteLine("----------------------------------------");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nom = reader.GetString(1);
                        string email = reader.GetString(2);
                        Console.WriteLine($"{id}\t{nom}\t\t{email}");
                    }
                }
            }
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
}

//• Exercice 3 – Insertion de données
//• Objectif : Ajouter un enregistrement depuis C#.
//• Énoncé :
//• Demander à l’utilisateur un nom et un email;
//• Insérer ces données dans la table Clients avec SqlCommand et paramètres.
void Exercice3()
{
    Console.WriteLine("\n--- Exercice 3 : Insertion de données ---");

    Console.Write("Entrez le nom du client : ");
    string? nom = Console.ReadLine();

    Console.Write("Entrez l'email du client : ");
    string? email = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("Le nom et l'email sont requis!");
        return;
    }

    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();

            string query = "INSERT INTO Clients (Nom, Email) VALUES (@Nom, @Email)";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Email", email);

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Client ajouté avec succès! ({rowsAffected} ligne(s) affectée(s))");
            }
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
}

//• Exercice 4 – Mise à jour de données
//• Objectif : Modifier un enregistrement existant.
//• Énoncé :
//• Demander à l’utilisateur l’ID d’un client et un nouvel email;
//• Mettre à jour l’email dans la base;
//• Afficher un message confirmant la modification.
void Exercice4()
{
    Console.WriteLine("\n--- Exercice 4 : Mise à jour de données ---");

    Console.Write("Entrez l'ID du client à modifier : ");
    string? idInput = Console.ReadLine();

    if (!int.TryParse(idInput, out int id))
    {
        Console.WriteLine("ID invalide!");
        return;
    }

    Console.Write("Entrez le nouvel email : ");
    string? email = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(email))
    {
        Console.WriteLine("L'email est requis!");
        return;
    }

    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();

            string query = "UPDATE Clients SET Email = @Email WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Email mis à jour avec succès! ({rowsAffected} ligne(s) affectée(s))");
                }
                else
                {
                    Console.WriteLine("Aucun client trouvé avec cet ID.");
                }
            }
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
}

//• Exercice 5 – Suppression de données
//• Objectif : Supprimer un enregistrement.
//• Énoncé :
//• Demander à l’utilisateur l’ID d’un client à supprimer;
//• Le supprimer de la table Clients;
//• Afficher "Client supprimé" si la suppression est réussie.
void Exercice5()
{
    Console.WriteLine("\n--- Exercice 5 : Suppression de données ---");

    Console.Write("Entrez l'ID du client à supprimer : ");
    string? idInput = Console.ReadLine();

    if (!int.TryParse(idInput, out int id))
    {
        Console.WriteLine("ID invalide!");
        return;
    }

    try
    {
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();

            string query = "DELETE FROM Clients WHERE Id = @Id";
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Client supprimé");
                }
                else
                {
                    Console.WriteLine("Aucun client trouvé avec cet ID.");
                }
            }
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
}