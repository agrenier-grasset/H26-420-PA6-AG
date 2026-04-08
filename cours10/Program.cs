using cours10;

// =============================================
// Exercice 1 – Classe de base pour entité
// =============================================
Console.WriteLine("=== Exercice 1 : Classe de base pour entité ===\n");

var clients = new List<Client>
{
    new() { Id = 1, Nom = "Alice Tremblay", Email = "alice@exemple.com"  },
    new() { Id = 2, Nom = "Bob Gagnon",     Email = "bob@exemple.com"    },
    new() { Id = 3, Nom = "Claire Dubois",  Email = "claire@exemple.com" }
};

foreach (Client c in clients)
    Console.WriteLine($"Id : {c.Id}, Nom : {c.Nom}, Email : {c.Email}");

// =============================================
// Exercice 2 – Séparation Présentation / Logique
// =============================================
Console.WriteLine("\n=== Exercice 2 : Séparation Présentation / Logique ===\n");

var emailPolicy = new EmailPolicyService();
IClientRepository repository = new ClientRepositoryADO();
var service = new ClientService(repository, emailPolicy);

Console.Write("Nom   : ");
string nom = Console.ReadLine() ?? string.Empty;
Console.Write("Email : ");
string email = Console.ReadLine() ?? string.Empty;

var nouveauClient = new Client { Nom = nom, Email = email };
try
{
    service.Validate(nouveauClient);
    Console.WriteLine(service.GetClientInfo(nouveauClient));
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Erreur de validation : {ex.Message}");
}

// =============================================
// Exercice 3 – Couche Données avec Repository
// =============================================
Console.WriteLine("\n=== Exercice 3 : Repository ADO.NET ===\n");

try
{
    List<Client> tousLesClients = service.ListClients();
    if (tousLesClients.Count == 0)
        Console.WriteLine("Aucun client dans la base de données.");
    else
        foreach (Client c in tousLesClients)
            Console.WriteLine(service.GetClientInfo(c));
}
catch (Exception ex)
{
    Console.WriteLine($"Erreur BD : {ex.Message}");
}

// =============================================
// Exercice 4 – Architecture 3 couches complète
// =============================================
Console.WriteLine("\n=== Exercice 4 : Architecture 3 couches ===\n");

bool continuer = true;
while (continuer)
{
    Console.WriteLine("--- Menu ---");
    Console.WriteLine("1. Ajouter un client");
    Console.WriteLine("2. Afficher un client par Id");
    Console.WriteLine("3. Lister tous les clients");
    Console.WriteLine("4. Quitter");
    Console.Write("Choix : ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("Nom   : ");
            string n = Console.ReadLine() ?? string.Empty;
            Console.Write("Email : ");
            string e = Console.ReadLine() ?? string.Empty;
            try
            {
                service.AddClient(n, e);
                Console.WriteLine("Client ajouté avec succès.\n");
            }
            catch (ArgumentException ex) { Console.WriteLine($"Erreur de validation : {ex.Message}\n"); }
            catch (Exception ex)         { Console.WriteLine($"Erreur BD : {ex.Message}\n"); }
            break;

        case "2":
            Console.Write("Id : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    Client? found = service.GetClientById(id);
                    Console.WriteLine(found is null
                        ? "Client introuvable.\n"
                        : service.GetClientInfo(found) + "\n");
                }
                catch (Exception ex) { Console.WriteLine($"Erreur BD : {ex.Message}\n"); }
            }
            else
                Console.WriteLine("Id invalide.\n");
            break;

        case "3":
            try
            {
                List<Client> liste = service.GetAllClients();
                if (liste.Count == 0)
                    Console.WriteLine("Aucun client.\n");
                else
                {
                    foreach (Client c in liste)
                        Console.WriteLine($"  [{c.Id}] {service.GetClientInfo(c)}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex) { Console.WriteLine($"Erreur BD : {ex.Message}\n"); }
            break;

        case "4":
            continuer = false;
            break;

        default:
            Console.WriteLine("Choix invalide.\n");
            break;
    }
}
