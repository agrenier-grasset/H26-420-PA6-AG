//• Exercice 1 – Propriétés automatiques
//• Objectif : Créer une classe simple avec des propriétés automatiques.
//• Énoncé :
//• Créer une classe Livre avec les propriétés suivantes :
//• Titre(string);
//• Auteur(string);
//• Pages(int).
//• Dans Main, créer un objet Livre, initialise ses propriétés, puis afficher les informations du livre.
void Exercice1()
{
    Console.WriteLine("=== Exercice 1 ===");
    Livre livre = new Livre
    {
        Titre = "Le Petit Prince",
        Auteur = "Antoine de Saint-Exupéry",
        Pages = 96
    };

    Console.WriteLine($"Titre: {livre.Titre}");
    Console.WriteLine($"Auteur: {livre.Auteur}");
    Console.WriteLine($"Pages: {livre.Pages}");
    Console.WriteLine();
}

//• Exercice 2 – Propriétés avec validation
//• Objectif : Ajouter de la logique dans les accesseurs.
//• Énoncé :
//• Créer une classe CompteBancaire avec une propriété Solde (decimal);
//• Le set doit refuser les valeurs négatives et lever une exception.
//• Dans Main, créer un compte et tenter d'assigner un solde négatif pour tester la validation.
void Exercice2()
{
    Console.WriteLine("=== Exercice 2 ===");
    CompteBancaire compte = new CompteBancaire();
    compte.Solde = 100;
    Console.WriteLine($"Solde initial: {compte.Solde} $");

    try
    {
        compte.Solde = -50;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Exception attrapée: {ex.Message}");
    }
    Console.WriteLine();
}

//• Exercice 3 – Exceptions personnalisées
//• Objectif : Créer et utiliser une exception personnalisée.
//• Énoncé :
//• Créer une exception SoldeInsuffisantException qui hérite d'Exception;
//• Créer une méthode Retirer(decimal montant) dans CompteBancaire qui lève cette exception si le solde est insuffisant.
//• Dans Main, tester le retrait avec un montant supérieur au solde.
void Exercice3()
{
    Console.WriteLine("=== Exercice 3 ===");
    CompteBancaire compte = new CompteBancaire();
    compte.Solde = 100;
    Console.WriteLine($"Solde initial: {compte.Solde} $");

    try
    {
        compte.Retirer(150);
    }
    catch (SoldeInsuffisantException ex)
    {
        Console.WriteLine($"Exception attrapée: {ex.Message}");
    }
    Console.WriteLine($"Solde final: {compte.Solde} $");
    Console.WriteLine();
}

//• Exercice 4 – Thread simple
//• Objectif : Créer et exécuter un thread.
//• Énoncé :
//• Créer une méthode AfficherMessage() qui affiche "Bonjour du thread" toutes les 2 secondes;
//• Lancer cette méthode dans un thread.
//• Pendant ce temps, le thread principal affiche "Main continue..." toutes les secondes, pendant 5
//secondes.
void AfficherMessage()
{
    for (int i = 0; i < 3; i++)
    {
        Console.WriteLine("Bonjour du thread");
        Thread.Sleep(2000);
    }
}

void Exercice4()
{
    Console.WriteLine("=== Exercice 4 ===");
    Thread thread = new Thread(AfficherMessage);
    thread.Start();

    for (int i = 0; i < 5; i++)
    {
        Console.WriteLine("Main continue...");
        Thread.Sleep(1000);
    }

    thread.Join();
    Console.WriteLine();
}

//• Exercice 5 – Synchronisation avec lock
//• Objectif : Protéger une ressource partagée entre threads.
//• Énoncé :
//• Créer une variable compteur partagée;
//• Lancer 3 threads qui incrémentent cette variable 1000 fois chacun;
//• Utiliser lock pour éviter les conflits.
//• Afficher le résultat final dans Main.
void Exercice5()
{
    Console.WriteLine("=== Exercice 5 ===");
    int compteur = 0;
    object verrou = new object();

    Thread[] threads = new Thread[3];
    for (int i = 0; i < 3; i++)
    {
        threads[i] = new Thread(() =>
        {
            for (int j = 0; j < 1000; j++)
            {
                lock (verrou)
                {
                    compteur++;
                }
            }
        });
        threads[i].Start();
    }

    foreach (Thread t in threads)
    {
        t.Join();
    }

    Console.WriteLine($"Valeur finale du compteur: {compteur}");
    Console.WriteLine($"Valeur attendue: 3000");
    Console.WriteLine();
}

//• Exercice 6 – Propriétés calculées + validation avancée
//• Objectif : Combiner propriétés calculées, validation et accesseurs privés.
//• Énoncé :
//• Créer une classe Produit avec :
//• Propriété Nom(string, lecture seule);
//• Propriété PrixUnitaire(decimal) avec validation :
//• Lever une ArgumentOutOfRangeException si prix ≤ 0;
//• Propriété Quantite(int) avec validation :
//• Lever ArgumentOutOfRangeException si quantite < 0;
//• Propriété calculée Total (decimal), lecture seule :
//• Total = PrixUnitaire * Quantite.
//• Dans Main :
//• Créer un produit valide et afficher ses infos;
//• Tenter d'assigner un prix négatif → doit générer une exception.
void Exercice6()
{
    Console.WriteLine("=== Exercice 6 ===");
    Produit produit = new Produit("Clavier", 49.99m, 5);
    Console.WriteLine($"Nom: {produit.Nom}");
    Console.WriteLine($"Prix unitaire: {produit.PrixUnitaire} $");
    Console.WriteLine($"Quantité: {produit.Quantite}");
    Console.WriteLine($"Total: {produit.Total} $");

    try
    {
        produit.PrixUnitaire = -10;
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Exception attrapée: {ex.Message}");
    }
    Console.WriteLine();
}

//• Exercice 7 – Exceptions personnalisées + innerException
//• Objectif : Construire une chaîne d'exceptions avec une cause initiale.
//• Énoncé :
//• Créer une exception personnalisée ErreurTechniqueException (hérite d'Exception);
//• Créer une classe ServicePaiement contenant une méthode TraiterPaiement() :
//• La méthode tente de convertir une chaîne en montant (decimal.Parse());
//• Si la conversion échoue, une FormatException est levée;
//• Attraper cette FormatException et relancer une ErreurTechniqueException, en la passant
//comme innerException.
//• Dans Main, appeler TraiterPaiement() avec une chaîne invalide et afficher :
//• Le message final;
//• Le message de l'innerException.
void Exercice7()
{
    Console.WriteLine("=== Exercice 7 ===");
    ServicePaiement service = new ServicePaiement();

    try
    {
        service.TraiterPaiement("montant_invalide");
    }
    catch (ErreurTechniqueException ex)
    {
        Console.WriteLine($"Message final: {ex.Message}");
        Console.WriteLine($"Message de l'innerException: {ex.InnerException?.Message}");
    }
    Console.WriteLine();
}

//• Exercice 8 – Threads + accès concurrent sans lock (détection d'erreurs)
//• Objectif : Observer un problème de data race avant correction.
//• Énoncé :
//• Créer une variable entière compteur = 0;
//• Lancer 5 threads, chacun incrémentant compteur 10 000 fois;
//• Ne pas utiliser lock pour cet exercice;
//• À la fin, afficher la valeur attendue (50 000) VS la valeur réelle;
//• Observer et commenter pourquoi la valeur réelle est incorrecte(conditions de course, manque
//d'exclusivité).
void Exercice8()
{
    Console.WriteLine("=== Exercice 8 ===");
    int compteur = 0;

    Thread[] threads = new Thread[5];
    for (int i = 0; i < 5; i++)
    {
        threads[i] = new Thread(() =>
        {
            for (int j = 0; j < 10000; j++)
            {
                compteur++;
            }
        });
        threads[i].Start();
    }

    foreach (Thread t in threads)
    {
        t.Join();
    }

    Console.WriteLine($"Valeur attendue: 50000");
    Console.WriteLine($"Valeur réelle: {compteur}");
    Console.WriteLine("La valeur est incorrecte à cause des conditions de course (data race).");
    Console.WriteLine("Plusieurs threads accèdent à la variable sans synchronisation.");
    Console.WriteLine();
}

//• Exercice 9 – Threads + lock : correction du data race
//• Objectif : Appliquer une synchronisation correcte.
//• Énoncé :
//• Reprendre le code de l'exercice 8;
//• Ajouter un objet readonly object verrou = new object(); ;
//• Entourer l'incrémentation de compteur avec un bloc lock(verrou) :
//• Relancer les 5 threads;
//• Comparer la valeur obtenue à la valeur attendue (50 000);
//• Expliquer pourquoi lock règle le problème.
void Exercice9()
{
    Console.WriteLine("=== Exercice 9 ===");
    int compteur = 0;
    object verrou = new object();

    Thread[] threads = new Thread[5];
    for (int i = 0; i < 5; i++)
    {
        threads[i] = new Thread(() =>
        {
            for (int j = 0; j < 10000; j++)
            {
                lock (verrou)
                {
                    compteur++;
                }
            }
        });
        threads[i].Start();
    }

    foreach (Thread t in threads)
    {
        t.Join();
    }

    Console.WriteLine($"Valeur attendue: 50000");
    Console.WriteLine($"Valeur réelle: {compteur}");
    Console.WriteLine("lock règle le problème en assurant l'exclusion mutuelle.");
    Console.WriteLine("Un seul thread peut incrémenter le compteur à la fois.");
    Console.WriteLine();
}

//• Exercice 10 – Multi-threads + AutoResetEvent
//• Objectif :
//• Coordonner plusieurs threads avec un mécanisme de signalisation.
//• Énoncé :
//• Créer un AutoResetEvent initialisé à false;
//• Créer un thread travailleur :
//• Il attend le signal (WaitOne()), puis affiche :
//• "Travailleur : je commence la tâche."
//• Dans le thread principal :
//• Attendre 2 secondes;
//• Afficher: "Main : signal envoyé!";
//• Appeler Set() pour débloquer le travailleur;
//• Une fois débloqué, le travailleur affiche 5 nombres (1 à 5) avec 1 seconde entre chaque.
void Exercice10()
{
    Console.WriteLine("=== Exercice 10 ===");
    AutoResetEvent signal = new AutoResetEvent(false);

    Thread travailleur = new Thread(() =>
    {
        signal.WaitOne();
        Console.WriteLine("Travailleur : je commence la tâche.");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"Nombre: {i}");
            Thread.Sleep(1000);
        }
    });
    travailleur.Start();

    Thread.Sleep(2000);
    Console.WriteLine("Main : signal envoyé!");
    signal.Set();

    travailleur.Join();
    Console.WriteLine();
}


// Programme principal
Exercice1();
Exercice2();
Exercice3();
Exercice4();
Exercice5();
Exercice6();
Exercice7();
Exercice8();
Exercice9();
Exercice10();
