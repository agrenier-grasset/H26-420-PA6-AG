using Microsoft.Data.SqlClient;
using RP = cours7.RepositoryPattern;

IRepository<Client> repository = new Repository<Client>();

repository.Add(new Client { Id = 1, Nom = "Alice", Email = "alice@example.com", DateInscription = new DateTime(2024, 5, 10) });
repository.Add(new Client { Id = 2, Nom = "Bruno", Email = "bruno@example.com", DateInscription = new DateTime(2023, 11, 2) });
repository.Add(new Client { Id = 3, Nom = "Chloé", Email = "chloe@example.com", DateInscription = new DateTime(2025, 1, 15) });

Console.WriteLine("=== Exercice 1 : Clients ===");
AfficherClients(repository.GetAll());

Console.WriteLine();
Console.WriteLine("=== Exercice 2 : Repository (suppression de l'id 2) ===");
repository.Remove(2);
AfficherClients(repository.GetAll());

Console.WriteLine();
Console.WriteLine("=== Exercice 3 : Tri par nom (IComparable) ===");
List<Client> clientsParNom = new List<Client>(repository.GetAll());
clientsParNom.Sort();
AfficherClients(clientsParNom);

Console.WriteLine();
Console.WriteLine("=== Exercice 3 : Tri par date d'inscription (IComparer) ===");
List<Client> clientsParDate = new List<Client>(repository.GetAll());
clientsParDate.Sort(new ClientParDate());
AfficherClients(clientsParDate);

Console.WriteLine();
Console.WriteLine("=== Exercice 4 : Chaine<Commande> + foreach ===");
Chaine<Commande> chaineCommandes = new Chaine<Commande>();
chaineCommandes.Ajouter(new Commande { Id = 101, ClientId = 1, Montant = 149.99m, Description = "Clavier", DateCommande = new DateTime(2025, 1, 20) });
chaineCommandes.Ajouter(new Commande { Id = 102, ClientId = 1, Montant = 39.90m, Description = "Souris", DateCommande = new DateTime(2025, 1, 21) });
chaineCommandes.Ajouter(new Commande { Id = 103, ClientId = 3, Montant = 799.00m, Description = "Écran", DateCommande = new DateTime(2025, 1, 22) });

foreach (Commande commande in chaineCommandes)
{
    Console.WriteLine($"Commande {commande.Id} | Client {commande.ClientId} | {commande.Description} | {commande.Montant:C} | {commande.DateCommande:yyyy-MM-dd}");
}

Console.WriteLine();
Console.WriteLine("=== Exercice 5 : Repository DB + Queue + Stack + tri ===");
string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Cours7_Exercice5;Trusted_Connection=True;TrustServerCertificate=True;";
CommandeRepository commandeRepository = new CommandeRepository(connectionString);

try
{
    Queue<Commande> fileCommandes = commandeRepository.LireCommandesEnFile(clientId: 1);
    List<Commande> commandesTriees = new List<Commande>(fileCommandes);
    commandesTriees.Sort(new CommandeParMontant());

    Console.WriteLine("Rapport des commandes triées par montant :");
    foreach (Commande commande in commandesTriees)
    {
        Console.WriteLine($"Id={commande.Id}, ClientId={commande.ClientId}, Montant={commande.Montant:C}, Description={commande.Description}, Date={commande.DateCommande:yyyy-MM-dd}");
    }

    Console.WriteLine();
    Console.WriteLine("Historique SQL (dernier exécuté en premier) :");
    foreach (string sql in commandeRepository.RequetesExecutees)
    {
        Console.WriteLine(sql);
    }
}
catch (SqlException ex)
{
    Console.WriteLine($"Lecture BD impossible: {ex.Message}");
    Console.WriteLine("Valide si la base MaBase et la table Commandes existent localement.");
}

Console.WriteLine();
Console.WriteLine("=== Exemple minimal : modèle + interface + abstraite + concrète ===");
RP.IRepository<RP.Lieu> lieuRepository = new RP.LieuRepository(connectionString);
Console.WriteLine(lieuRepository.GetType().Name);

static void AfficherClients(IEnumerable<Client> clients)
{
    foreach (Client client in clients)
    {
        Console.WriteLine($"Id: {client.Id}, Nom: {client.Nom}, Email: {client.Email}, DateInscription: {client.DateInscription:yyyy-MM-dd}");
    }
}
