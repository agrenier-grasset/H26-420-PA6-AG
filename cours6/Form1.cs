using Microsoft.Data.SqlClient;
using System.Data;

namespace cours6
{
    public partial class Form1 : Form
    {
        private readonly string nomBaseDonnees = "Exercices_Cours6";
        private readonly string connectionString;
        private readonly string masterConnectionString;
        private DataSet? dataSetClients;
        private DataRepository? repository;
        private int selectedClientEx5Id = -1;
        private int selectedCommandeEx5Id = -1;

        public Form1()
        {
            connectionString = $"Server=(localdb)\\mssqllocaldb;Database={nomBaseDonnees};" +
                "Trusted_Connection=True;MultipleActiveResultSets=true";

            masterConnectionString = "Server=(localdb)\\mssqllocaldb;Database=master;" +
                "Trusted_Connection=True;";

            repository = new DataRepository(connectionString);

            InitialiserBaseDeDonnees();
            InitializeComponent();
            InitialiserDataGridViews();
            InsererDonneesTest();
            AfficherCommandes();
            RafraichirEx5Clients();
        }

        private void InitialiserDataGridViews()
        {
            // Exercice 1
            if (dgvClients != null)
            {
                dgvClients.Columns.Add("Id", "ID");
                dgvClients.Columns.Add("Nom", "Nom");
                dgvClients.Columns.Add("Email", "Email");
                dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Exercice 2
            if (dgvCommandes != null)
            {
                dgvCommandes.Columns.Add("CommandeId", "ID Commande");
                dgvCommandes.Columns.Add("ClientId", "ID Client");
                dgvCommandes.Columns.Add("ClientNom", "Nom Client");
                dgvCommandes.Columns.Add("Montant", "Montant");
                dgvCommandes.Columns.Add("Description", "Description");
                dgvCommandes.Columns.Add("DateCommande", "Date");
                dgvCommandes.Columns.Add("Solde", "Solde Client");
                dgvCommandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Exercice 3
            if (dgvDataSet != null)
            {
                dgvDataSet.Columns.Add("Id", "ID");
                dgvDataSet.Columns.Add("Nom", "Nom");
                dgvDataSet.Columns.Add("Email", "Email");
                dgvDataSet.Columns.Add("Solde", "Solde");
                dgvDataSet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Exercice 4
            if (dgvCommandesDetail != null)
            {
                dgvCommandesDetail.Columns.Add("Id", "ID Commande");
                dgvCommandesDetail.Columns.Add("Montant", "Montant");
                dgvCommandesDetail.Columns.Add("Description", "Description");
                dgvCommandesDetail.Columns.Add("DateCommande", "Date");
                dgvCommandesDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            // Exercice 5
            if (dgvEx5Clients != null)
            {
                dgvEx5Clients.Columns.Add("Id", "ID");
                dgvEx5Clients.Columns.Add("Nom", "Nom");
                dgvEx5Clients.Columns.Add("Email", "Email");
                dgvEx5Clients.Columns.Add("Solde", "Solde");
                dgvEx5Clients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (dgvEx5Commandes != null)
            {
                dgvEx5Commandes.Columns.Add("Id", "ID");
                dgvEx5Commandes.Columns.Add("Montant", "Montant");
                dgvEx5Commandes.Columns.Add("Description", "Description");
                dgvEx5Commandes.Columns.Add("DateCommande", "Date");
                dgvEx5Commandes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                    // Drop database if it exists
                    string checkDbQuery = $"SELECT database_id FROM sys.databases WHERE name = '{nomBaseDonnees}'";
                    using (SqlCommand checkCommand = new SqlCommand(checkDbQuery, connection))
                    {
                        object? result = checkCommand.ExecuteScalar();

                        if (result != null)
                        {
                            Console.WriteLine($"Suppression de la base de données existante '{nomBaseDonnees}'...");
                            string dropDbQuery = $"ALTER DATABASE {nomBaseDonnees} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE {nomBaseDonnees}";
                            using (SqlCommand dropCommand = new SqlCommand(dropDbQuery, connection))
                            {
                                dropCommand.ExecuteNonQuery();
                                Console.WriteLine($"Base de données '{nomBaseDonnees}' supprimée!");
                            }
                        }
                    }

                    // Create new database
                    Console.WriteLine($"Création de la base de données '{nomBaseDonnees}'...");
                    string createDbQuery = $"CREATE DATABASE {nomBaseDonnees}";
                    using (SqlCommand createCommand = new SqlCommand(createDbQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine($"Base de données '{nomBaseDonnees}' créée avec succès!");
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Créer table Clients avec champ Solde
                    Console.WriteLine("Création de la table 'Clients'...");
                    string createClientsQuery = @"
                        CREATE TABLE Clients (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Nom NVARCHAR(100) NOT NULL,
                            Email NVARCHAR(100) NOT NULL,
                            Solde DECIMAL(10, 2) DEFAULT 0
                        )";

                    using (SqlCommand createCommand = new SqlCommand(createClientsQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine("Table 'Clients' créée avec succès!");
                    }

                    // Créer table Commandes
                    Console.WriteLine("Création de la table 'Commandes'...");
                    string createCommandesQuery = @"
                        CREATE TABLE Commandes (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            ClientId INT NOT NULL,
                            Montant DECIMAL(10, 2) NOT NULL,
                            Description NVARCHAR(200),
                            DateCommande DATETIME DEFAULT GETDATE(),
                            FOREIGN KEY (ClientId) REFERENCES Clients(Id)
                        )";

                    using (SqlCommand createCommand = new SqlCommand(createCommandesQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                        Console.WriteLine("Table 'Commandes' créée avec succès!");
                    }
                }

                Console.WriteLine("Initialisation terminée!\n");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Erreur SQL lors de l'initialisation : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur générale lors de l'initialisation : {ex.Message}\n");
            }
        }

        private void InsererDonneesTest()
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Vérifier et insérer des données de test pour Clients
                    string checkQuery = "SELECT COUNT(*) FROM Clients";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, sqlConnection))
                    {
                        object? result = checkCommand.ExecuteScalar();
                        int count = result != null ? (int)result : 0;
                        if (count == 0)
                        {
                            string insertQuery = @"
                                INSERT INTO Clients (Nom, Email, Solde) VALUES
                                ('Jean Dupont', 'jean.dupont@gmail.com', 500.00),
                                ('Marie Martin', 'marie.martin@outlook.com', 750.00),
                                ('Pierre Durand', 'pierre.durand@gmail.com', 1000.00),
                                ('Sophie Bernard', 'sophie.bernard@yahoo.com', 600.00),
                                ('Luc Petit', 'luc.petit@gmail.com', 800.00),
                                ('Anne Moreau', 'anne.moreau@hotmail.com', 450.00)";

                            using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    // Vérifier et insérer des données de test pour Commandes
                    string checkCommandesQuery = "SELECT COUNT(*) FROM Commandes";
                    using (SqlCommand checkCommand = new SqlCommand(checkCommandesQuery, sqlConnection))
                    {
                        object? result = checkCommand.ExecuteScalar();
                        int count = result != null ? (int)result : 0;
                        if (count == 0)
                        {
                            string insertCommandesQuery = @"
                                INSERT INTO Commandes (ClientId, Montant, Description, DateCommande) VALUES
                                (1, 150.50, 'Achat de fournitures', DATEADD(DAY, -10, GETDATE())),
                                (1, 75.25, 'Commande de livres', DATEADD(DAY, -5, GETDATE())),
                                (2, 200.00, 'Service de consultation', DATEADD(DAY, -8, GETDATE())),
                                (3, 500.00, 'Achat de matériel', DATEADD(DAY, -3, GETDATE())),
                                (3, 125.75, 'Fournitures supplémentaires', DATEADD(DAY, -1, GETDATE())),
                                (4, 300.00, 'Service client premium', DATEADD(DAY, -7, GETDATE())),
                                (5, 450.00, 'Achat en gros', DATEADD(DAY, -4, GETDATE())),
                                (6, 99.99, 'Petit achat', DATEADD(DAY, -2, GETDATE()))";

                            using (SqlCommand insertCommand = new SqlCommand(insertCommandesQuery, sqlConnection))
                            {
                                insertCommand.ExecuteNonQuery();
                            }

                            Console.WriteLine("Données de test pour Commandes insérées avec succès!");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherCommandes()
        {
            try
            {
                if (dgvCommandes == null) return;

                dgvCommandes.Rows.Clear();

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    string query = @"
                        SELECT 
                            c.Id,
                            c.ClientId,
                            cl.Nom,
                            c.Montant,
                            c.Description,
                            c.DateCommande,
                            cl.Solde
                        FROM Commandes c
                        INNER JOIN Clients cl ON c.ClientId = cl.Id
                        ORDER BY c.DateCommande DESC";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvCommandes.Rows.Add(
                                    reader.GetInt32(0),
                                    reader.GetInt32(1),
                                    reader.GetString(2),
                                    reader.GetDecimal(3),
                                    reader.GetString(4),
                                    reader.GetDateTime(5).ToString("yyyy-MM-dd HH:mm"),
                                    reader.GetDecimal(6)
                                );
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== EXERCICE 1 =====
        private void ButtonRechercher_Click(object? sender, EventArgs e)
        {
            if (dgvClients == null || string.IsNullOrWhiteSpace(txtDomaine?.Text))
            {
                MessageBox.Show("Veuillez entrer un domaine de courriel.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                dgvClients.Rows.Clear();

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Utiliser SqlParameter pour éviter l'injection SQL
                    string query = "SELECT Id, Nom, Email FROM Clients WHERE Email LIKE @domaine";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        // Ajouter le paramètre de manière sécurisée
                        command.Parameters.AddWithValue("@domaine", "%" + txtDomaine.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                MessageBox.Show("Aucun client trouvé avec ce domaine.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nom = reader.GetString(1);
                                string email = reader.GetString(2);

                                dgvClients.Rows.Add(id, nom, email);
                            }
                        }
                    }
                }

                MessageBox.Show($"Recherche complétée : {dgvClients.Rows.Count} client(s) trouvé(s).", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur générale : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== EXERCICE 2 =====
        private void ButtonAjouterCommande_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtClientId?.Text, out int clientId))
            {
                lblStatutTransaction!.Text = "Statut: [ERREUR] Erreur - ID client invalide";
                MessageBox.Show("Veuillez entrer un ID client valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtMontant?.Text, out decimal montant) || montant <= 0)
            {
                lblStatutTransaction!.Text = "Statut: [ERREUR] Erreur - Montant invalide";
                MessageBox.Show("Veuillez entrer un montant valide (> 0).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string description = txtDescription?.Text ?? "";

            try
            {
                lblStatutTransaction!.Text = "Statut: [EN COURS] Transaction en cours...";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    // Démarrer une transaction
                    using (SqlTransaction transaction = sqlConnection.BeginTransaction())
                    {
                        try
                        {
                            // Vérifier que le client existe
                            string checkClientQuery = "SELECT Solde FROM Clients WHERE Id = @clientId";
                            using (SqlCommand checkCommand = new SqlCommand(checkClientQuery, sqlConnection, transaction))
                            {
                                checkCommand.Parameters.AddWithValue("@clientId", clientId);
                                object? result = checkCommand.ExecuteScalar();

                                if (result == null)
                                {
                                    transaction.Rollback();
                                    lblStatutTransaction.Text = "Statut: [ERREUR] Erreur - Client non trouvé";
                                    MessageBox.Show($"Le client avec l'ID {clientId} n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                decimal soldeActuel = (decimal)result;

                                // Ajouter la commande
                                string insertCommandeQuery = @"
                                    INSERT INTO Commandes (ClientId, Montant, Description, DateCommande)
                                    VALUES (@clientId, @montant, @description, GETDATE())";

                                using (SqlCommand insertCommand = new SqlCommand(insertCommandeQuery, sqlConnection, transaction))
                                {
                                    insertCommand.Parameters.AddWithValue("@clientId", clientId);
                                    insertCommand.Parameters.AddWithValue("@montant", montant);
                                    insertCommand.Parameters.AddWithValue("@description", description);
                                    insertCommand.ExecuteNonQuery();
                                }

                                // Mettre à jour le solde du client
                                decimal nouveauSolde = soldeActuel - montant;
                                string updateSoldeQuery = "UPDATE Clients SET Solde = @nouveauSolde WHERE Id = @clientId";

                                using (SqlCommand updateCommand = new SqlCommand(updateSoldeQuery, sqlConnection, transaction))
                                {
                                    updateCommand.Parameters.AddWithValue("@nouveauSolde", nouveauSolde);
                                    updateCommand.Parameters.AddWithValue("@clientId", clientId);
                                    updateCommand.ExecuteNonQuery();
                                }

                                // Valider la transaction
                                transaction.Commit();
                                lblStatutTransaction.Text = $"Statut: [OK] Transaction réussie - Nouveau solde: {nouveauSolde:C}";
                                MessageBox.Show($"Commande ajoutée avec succès!\nNouveau solde du client: {nouveauSolde:C}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Rafraîchir l'affichage
                                txtClientId!.Clear();
                                txtMontant!.Clear();
                                txtDescription!.Clear();
                                AfficherCommandes();
                            }
                        }
                        catch (SqlException ex)
                        {
                            // Annuler la transaction en cas d'erreur
                            transaction.Rollback();
                            lblStatutTransaction!.Text = "Statut: [ERREUR] Erreur - Transaction annulée (Rollback)";
                            MessageBox.Show($"Erreur SQL : {ex.Message}\nLa transaction a été annulée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatutTransaction!.Text = "Statut: [ERREUR] Erreur générale";
                MessageBox.Show($"Erreur générale : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== EXERCICE 3 - DataSet et DataAdapter =====
        private void ButtonChargerDataSet_Click(object? sender, EventArgs e)
        {
            try
            {
                lblStatutDataSet!.Text = "Statut: [EN COURS] Chargement du DataSet...";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    dataSetClients = new DataSet();

                    string query = "SELECT Id, Nom, Email, Solde FROM Clients";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                    {
                        adapter.Fill(dataSetClients, "Clients");
                    }
                }

                AfficherDataSet();
                lblStatutDataSet.Text = "Statut: [OK] DataSet chargé en mémoire";
                MessageBox.Show($"DataSet chargé avec {dataSetClients?.Tables["Clients"]?.Rows.Count ?? 0} clients.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur SQL lors du chargement";
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur générale";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonModifierClient_Click(object? sender, EventArgs e)
        {
            if (dataSetClients == null || dataSetClients.Tables["Clients"]?.Rows.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger le DataSet.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtClientIdEx3?.Text, out int clientId))
            {
                MessageBox.Show("Veuillez entrer un ID client valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNouveauNom?.Text))
            {
                MessageBox.Show("Veuillez entrer un nouveau nom.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatutDataSet!.Text = "Statut: [EN COURS] Modification en mémoire...";

                DataTable clientsTable = dataSetClients.Tables["Clients"]!;
                DataRow? row = clientsTable.Rows.Cast<DataRow>().FirstOrDefault(r => (int)r["Id"] == clientId);

                if (row == null)
                {
                    lblStatutDataSet.Text = "Statut: [ERREUR] Erreur - Client non trouvé";
                    MessageBox.Show($"Le client avec l'ID {clientId} n'existe pas dans le DataSet.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                row["Nom"] = txtNouveauNom.Text;
                lblStatutDataSet.Text = $"Statut: [OK] Client modifié en mémoire (ID: {clientId})";
                MessageBox.Show($"Nom du client {clientId} modifié en: {txtNouveauNom.Text}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AfficherDataSet();
                txtClientIdEx3!.Clear();
                txtNouveauNom!.Clear();
            }
            catch (Exception ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur lors de la modification";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAjouterClient_Click(object? sender, EventArgs e)
        {
            if (dataSetClients == null || dataSetClients.Tables["Clients"]?.Rows.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger le DataSet.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomNouveau?.Text))
            {
                MessageBox.Show("Veuillez entrer un nom.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmailNouveau?.Text))
            {
                MessageBox.Show("Veuillez entrer un email.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtSoldeNouveau?.Text, out decimal solde))
            {
                MessageBox.Show("Veuillez entrer un solde valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                lblStatutDataSet!.Text = "Statut: [EN COURS] Ajout du client en mémoire...";

                DataTable clientsTable = dataSetClients.Tables["Clients"]!;
                DataRow newRow = clientsTable.NewRow();
                
                newRow["Nom"] = txtNomNouveau.Text;
                newRow["Email"] = txtEmailNouveau.Text;
                newRow["Solde"] = solde;

                clientsTable.Rows.Add(newRow);

                lblStatutDataSet.Text = $"Statut: [OK] Client ajouté en mémoire: {txtNomNouveau.Text}";
                MessageBox.Show($"Client '{txtNomNouveau.Text}' ajouté au DataSet.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AfficherDataSet();
                txtNomNouveau!.Clear();
                txtEmailNouveau!.Clear();
                txtSoldeNouveau!.Clear();
            }
            catch (Exception ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur lors de l'ajout";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSynchroniser_Click(object? sender, EventArgs e)
        {
            if (dataSetClients == null || dataSetClients.Tables["Clients"]?.Rows.Count == 0)
            {
                MessageBox.Show("Il n'y a rien à synchroniser.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatutDataSet!.Text = "Statut: [EN COURS] Synchronisation avec la base de données...";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Nom, Email, Solde FROM Clients", sqlConnection))
                    {
                        // Configurer les commandes pour Update, Insert, Delete
                        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                        // Synchroniser les modifications
                        int rowsAffected = adapter.Update(dataSetClients, "Clients");

                        lblStatutDataSet.Text = $"Statut: [OK] Synchronisation réussie ({rowsAffected} ligne(s) modifiée(s))";
                        MessageBox.Show($"Synchronisation réussie!\n{rowsAffected} ligne(s) modifiée(s) dans la base de données.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Rafraîchir le DataSet avec les dernières données
                        dataSetClients.Clear();
                        adapter.Fill(dataSetClients, "Clients");
                        AfficherDataSet();
                    }
                }
            }
            catch (SqlException ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur SQL lors de la synchronisation";
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur lors de la synchronisation";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonRafraichir_Click(object? sender, EventArgs e)
        {
            if (dataSetClients == null)
            {
                MessageBox.Show("Veuillez d'abord charger le DataSet.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatutDataSet!.Text = "Statut: [EN COURS] Rafraîchissement...";

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id, Nom, Email, Solde FROM Clients", sqlConnection))
                    {
                        dataSetClients.Clear();
                        adapter.Fill(dataSetClients, "Clients");
                    }
                }

                AfficherDataSet();
                lblStatutDataSet.Text = "Statut: [OK] DataSet rafraîchi";
                MessageBox.Show("DataSet rafraîchi avec les dernières données de la base.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur SQL lors du rafraîchissement";
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatutDataSet!.Text = "Statut: [ERREUR] Erreur lors du rafraîchissement";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherDataSet()
        {
            try
            {
                if (dgvDataSet == null || dataSetClients == null) return;

                dgvDataSet.Rows.Clear();

                if (dataSetClients.Tables["Clients"] == null) return;

                foreach (DataRow row in dataSetClients.Tables["Clients"]!.Rows)
                {
                    dgvDataSet.Rows.Add(
                        row["Id"],
                        row["Nom"],
                        row["Email"],
                        row["Solde"]
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== EXERCICE 4 - DataRelation et Jointure =====
        private void ButtonChargerRelations_Click(object? sender, EventArgs e)
        {
            try
            {
                lblStatutRelation!.Text = "Statut: [EN COURS] Chargement des données avec relations...";

                DataSet dataSetRelation = new DataSet();

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    // Charger la table Clients
                    using (SqlDataAdapter adapterClients = new SqlDataAdapter("SELECT Id, Nom, Email, Solde FROM Clients", sqlConnection))
                    {
                        adapterClients.Fill(dataSetRelation, "Clients");
                    }

                    // Charger la table Commandes
                    using (SqlDataAdapter adapterCommandes = new SqlDataAdapter("SELECT Id, ClientId, Montant, Description, DateCommande FROM Commandes", sqlConnection))
                    {
                        adapterCommandes.Fill(dataSetRelation, "Commandes");
                    }
                }

                // Créer la relation entre les deux tables
                DataRelation relation = new DataRelation(
                    "FK_Clients_Commandes",
                    dataSetRelation.Tables["Clients"]!.Columns["Id"],
                    dataSetRelation.Tables["Commandes"]!.Columns["ClientId"]
                );

                dataSetRelation.Relations.Add(relation);

                // Afficher les données avec la relation
                AfficherRelations(dataSetRelation);

                lblStatutRelation.Text = $"Statut: [OK] Données chargées - {dataSetRelation.Tables["Clients"]?.Rows.Count ?? 0} clients, {dataSetRelation.Tables["Commandes"]?.Rows.Count ?? 0} commandes";
                MessageBox.Show("Données chargées avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                lblStatutRelation!.Text = "Statut: [ERREUR] Erreur SQL";
                MessageBox.Show($"Erreur SQL : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatutRelation!.Text = "Statut: [ERREUR] Erreur générale";
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherRelations(DataSet dataSet)
        {
            try
            {
                if (trvClients == null) return;

                trvClients.Nodes.Clear();

                DataTable clientsTable = dataSet.Tables["Clients"]!;

                // Pour chaque client, créer un nœud et ajouter ses commandes comme enfants
                foreach (DataRow clientRow in clientsTable.Rows)
                {
                    int clientId = (int)clientRow["Id"];
                    string clientName = clientRow["Nom"].ToString() ?? "Inconnu";
                    string clientEmail = clientRow["Email"].ToString() ?? "";
                    decimal clientSolde = (decimal)clientRow["Solde"];

                    // Créer le nœud client avec ses informations
                    TreeNode clientNode = new TreeNode($"{clientName} ({clientEmail}) - Solde: {clientSolde:C}");
                    clientNode.Tag = new { Id = clientId, Type = "Client", Row = clientRow, DataSet = dataSet };

                    // Récupérer les commandes liées à ce client via la relation
                    DataRow[] commandesRows = clientRow.GetChildRows(dataSet.Relations["FK_Clients_Commandes"]!);

                    if (commandesRows.Length == 0)
                    {
                        TreeNode noCommandNode = new TreeNode("(Aucune commande)");
                        clientNode.Nodes.Add(noCommandNode);
                    }
                    else
                    {
                        foreach (DataRow commandeRow in commandesRows)
                        {
                            int commandeId = (int)commandeRow["Id"];
                            decimal montant = (decimal)commandeRow["Montant"];
                            string description = commandeRow["Description"].ToString() ?? "";
                            DateTime dateCommande = (DateTime)commandeRow["DateCommande"];

                            string commandeText = $"Commande #{commandeId} - {montant:C} ({dateCommande:dd/MM/yyyy})";
                            TreeNode commandeNode = new TreeNode(commandeText);
                            commandeNode.Tag = new { Id = commandeId, Type = "Commande", Row = commandeRow };

                            clientNode.Nodes.Add(commandeNode);
                        }
                    }

                    trvClients.Nodes.Add(clientNode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'affichage des relations : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfficherCommandesDetail()
        {
            try
            {
                if (dgvCommandesDetail == null || trvClients?.SelectedNode == null) return;

                dgvCommandesDetail.Rows.Clear();

                TreeNode selectedNode = trvClients.SelectedNode;
                if (selectedNode.Tag == null) return;

                dynamic tag = selectedNode.Tag;
                if (tag.Type == "Commande")
                {
                    DataRow row = tag.Row;
                    dgvCommandesDetail.Rows.Add(
                        row["Id"],
                        row["Montant"],
                        row["Description"],
                        ((DateTime)row["DateCommande"]).ToString("yyyy-MM-dd HH:mm")
                    );
                }
                else if (tag.Type == "Client")
                {
                    DataSet dataSet = tag.DataSet;
                    DataRow clientRow = tag.Row;
                    int clientId = tag.Id;

                    // Afficher toutes les commandes du client
                    DataRow[] commandesRows = clientRow.GetChildRows(dataSet.Relations["FK_Clients_Commandes"]!);

                    foreach (DataRow commandeRow in commandesRows)
                    {
                        dgvCommandesDetail.Rows.Add(
                            commandeRow["Id"],
                            commandeRow["Montant"],
                            commandeRow["Description"],
                            ((DateTime)commandeRow["DateCommande"]).ToString("yyyy-MM-dd HH:mm")
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TreeViewClients_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            AfficherCommandesDetail();
        }

        // ===== EXERCICE 5 - CRUD Complet =====
        private void RafraichirEx5Clients()
        {
            try
            {
                if (dgvEx5Clients == null || repository == null) return;

                dgvEx5Clients.Rows.Clear();
                DataTable clients = repository.GetAllClients();

                foreach (DataRow row in clients.Rows)
                {
                    dgvEx5Clients.Rows.Add(
                        row["Id"],
                        row["Nom"],
                        row["Email"],
                        row["Solde"]
                    );
                }
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur lors du chargement des clients: {ex.Message}";
            }
        }

        private void RafraichirEx5Commandes(int clientId)
        {
            try
            {
                if (dgvEx5Commandes == null || repository == null) return;

                dgvEx5Commandes.Rows.Clear();
                DataTable commandes = repository.GetCommandesByClientId(clientId);

                foreach (DataRow row in commandes.Rows)
                {
                    dgvEx5Commandes.Rows.Add(
                        row["Id"],
                        row["Montant"],
                        row["Description"],
                        ((DateTime)row["DateCommande"]).ToString("dd/MM/yyyy HH:mm")
                    );
                }

                lblStatutEx5!.Text = $"Commandes du client sélectionné: {commandes.Rows.Count} trouvée(s)";
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur lors du chargement des commandes: {ex.Message}";
            }
        }

        private void DataGridViewEx5Clients_SelectionChanged(object? sender, EventArgs e)
        {
            try
            {
                if (dgvEx5Clients?.SelectedRows.Count > 0)
                {
                    int clientId = (int)dgvEx5Clients.SelectedRows[0].Cells["Id"].Value;
                    string nom = dgvEx5Clients.SelectedRows[0].Cells["Nom"].Value.ToString() ?? "";
                    string email = dgvEx5Clients.SelectedRows[0].Cells["Email"].Value.ToString() ?? "";
                    decimal solde = (decimal)dgvEx5Clients.SelectedRows[0].Cells["Solde"].Value;

                    selectedClientEx5Id = clientId;
                    
                    txtEx5Nom!.Text = nom;
                    txtEx5Email!.Text = email;
                    txtEx5Solde!.Text = solde.ToString("F2");

                    RafraichirEx5Commandes(clientId);
                }
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5AddClient_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEx5Nom?.Text))
                {
                    lblStatutEx5!.Text = "Erreur: Le nom est obligatoire.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEx5Email?.Text))
                {
                    lblStatutEx5!.Text = "Erreur: L'email est obligatoire.";
                    return;
                }

                if (!decimal.TryParse(txtEx5Solde?.Text, out decimal solde))
                {
                    lblStatutEx5!.Text = "Erreur: Le solde doit être un nombre valide.";
                    return;
                }

                if (repository!.AddClient(txtEx5Nom.Text, txtEx5Email.Text, solde))
                {
                    lblStatutEx5.Text = $"[OK] Client '{txtEx5Nom.Text}' ajouté avec succès.";
                    txtEx5Nom.Clear();
                    txtEx5Email.Clear();
                    txtEx5Solde.Text = "0";
                    RafraichirEx5Clients();
                }
                else
                {
                    lblStatutEx5.Text = "Erreur lors de l'ajout du client.";
                }
            }
            catch (ArgumentException ex)
            {
                lblStatutEx5!.Text = $"Validation: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5UpdateClient_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedClientEx5Id < 0)
                {
                    lblStatutEx5!.Text = "Erreur: Sélectionnez un client d'abord.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEx5Nom?.Text))
                {
                    lblStatutEx5!.Text = "Erreur: Le nom est obligatoire.";
                    return;
                }

                if (!decimal.TryParse(txtEx5Solde?.Text, out decimal solde))
                {
                    lblStatutEx5!.Text = "Erreur: Le solde doit être un nombre valide.";
                    return;
                }

                if (repository!.UpdateClient(selectedClientEx5Id, txtEx5Nom.Text, txtEx5Email!.Text, solde))
                {
                    lblStatutEx5.Text = $"[OK] Client '{txtEx5Nom.Text}' modifié avec succès.";
                    RafraichirEx5Clients();
                }
                else
                {
                    lblStatutEx5.Text = "Erreur lors de la modification du client.";
                }
            }
            catch (ArgumentException ex)
            {
                lblStatutEx5!.Text = $"Validation: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5DeleteClient_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedClientEx5Id < 0)
                {
                    lblStatutEx5!.Text = "Erreur: Sélectionnez un client d'abord.";
                    return;
                }

                string clientName = txtEx5Nom?.Text ?? "Inconnu";
                DialogResult result = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer '{clientName}' et toutes ses commandes?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    if (repository!.DeleteClient(selectedClientEx5Id))
                    {
                        lblStatutEx5!.Text = $"[OK] Client '{clientName}' et ses commandes supprimés.";
                        txtEx5Nom!.Clear();
                        txtEx5Email!.Clear();
                        txtEx5Solde!.Text = "0";
                        selectedClientEx5Id = -1;
                        RafraichirEx5Clients();
                        if (dgvEx5Commandes != null)
                            dgvEx5Commandes.Rows.Clear();
                    }
                    else
                    {
                        lblStatutEx5.Text = "Erreur lors de la suppression du client.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5AddCommande_Click(object? sender, EventArgs e)
        {
            try
            {
                if (selectedClientEx5Id < 0)
                {
                    lblStatutEx5!.Text = "Erreur: Sélectionnez un client d'abord.";
                    return;
                }

                if (!decimal.TryParse(txtEx5Montant?.Text, out decimal montant))
                {
                    lblStatutEx5!.Text = "Erreur: Le montant doit être un nombre valide.";
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEx5Description?.Text))
                {
                    lblStatutEx5!.Text = "Erreur: La description est obligatoire.";
                    return;
                }

                if (repository!.AddCommande(selectedClientEx5Id, montant, txtEx5Description.Text))
                {
                    lblStatutEx5.Text = $"[OK] Commande de {montant:C} ajoutée avec succès.";
                    txtEx5Montant!.Clear();
                    txtEx5Description!.Clear();
                    RafraichirEx5Commandes(selectedClientEx5Id);
                    RafraichirEx5Clients();
                }
                else
                {
                    lblStatutEx5.Text = "Erreur lors de l'ajout de la commande.";
                }
            }
            catch (ArgumentException ex)
            {
                lblStatutEx5!.Text = $"Validation: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5UpdateCommande_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvEx5Commandes?.SelectedRows.Count == 0)
                {
                    lblStatutEx5!.Text = "Erreur: Sélectionnez une commande d'abord.";
                    return;
                }

                selectedCommandeEx5Id = (int)dgvEx5Commandes.SelectedRows[0].Cells["Id"].Value;

                if (!decimal.TryParse(txtEx5Montant?.Text, out decimal montant))
                {
                    lblStatutEx5!.Text = "Erreur: Le montant doitêtre un nombre valide.";
                    return;
                }

                if (repository!.UpdateCommande(selectedCommandeEx5Id, montant, txtEx5Description!.Text))
                {
                    lblStatutEx5.Text = $"[OK] Commande modifiée avec succès.";
                    txtEx5Montant!.Clear();
                    txtEx5Description!.Clear();
                    RafraichirEx5Commandes(selectedClientEx5Id);
                }
                else
                {
                    lblStatutEx5.Text = "Erreur lors de la modification de la commande.";
                }
            }
            catch (ArgumentException ex)
            {
                lblStatutEx5!.Text = $"Validation: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }

        private void ButtonEx5DeleteCommande_Click(object? sender, EventArgs e)
        {
            try
            {
                if (dgvEx5Commandes?.SelectedRows.Count == 0)
                {
                    lblStatutEx5!.Text = "Erreur: Sélectionnez une commande d'abord.";
                    return;
                }

                selectedCommandeEx5Id = (int)dgvEx5Commandes.SelectedRows[0].Cells["Id"].Value;

                DialogResult result = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cette commande?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    if (repository!.DeleteCommande(selectedCommandeEx5Id, selectedClientEx5Id))
                    {
                        lblStatutEx5!.Text = $"[OK] Commande supprimée avec succès.";
                        RafraichirEx5Commandes(selectedClientEx5Id);
                        RafraichirEx5Clients();
                    }
                    else
                    {
                        lblStatutEx5.Text = "Erreur lors de la suppression de la commande.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatutEx5!.Text = $"Erreur: {ex.Message}";
            }
        }
    }
}







