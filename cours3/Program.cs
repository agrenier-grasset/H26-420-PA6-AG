using System.Text;

//• Exercice 1 – Tableaux et opérations
//• Objectif : Déclarer et manipuler un tableau.
//• Énoncé :
//• Créer un tableau int[] contenant 5 nombres prédéfinis;
//• Afficher la somme des éléments avec Sum() (LINQ);
//• Afficher le nombre d'éléments avec Length;
//• (Pas de boucle : utiliser directement les méthodes intégrées).
void Exercice1()
{
    Console.WriteLine("=== Exercice 1 ===");
    int[] nombres = [10, 20, 30, 40, 50];
    Console.WriteLine($"Somme : {nombres.Sum()}");
    Console.WriteLine($"Nombre d'éléments : {nombres.Length}");
    Console.WriteLine();
}

//• Exercice 2 – Collections (List<T>)
//• Objectif : Utiliser une liste dynamique et ses méthodes.
//• Énoncé :
//• Créer une List<string> avec 3 prénoms;
//• Ajouter un prénom avec Add();
//• Supprimer un prénom avec Remove();
//• Afficher le nombre total avec Count.
void Exercice2()
{
    Console.WriteLine("=== Exercice 2 ===");
    List<string> prenoms = ["Alice", "Bob", "Charles"];
    prenoms.Add("David");
    prenoms.Remove("Bob");
    Console.WriteLine($"Nombre de prénoms : {prenoms.Count}");
    Console.WriteLine($"Prénoms : {string.Join(", ", prenoms)}");
    Console.WriteLine();
}

//• Exercice 3 – Chaînes et opérations
//• Objectif : Manipuler des string avec les méthodes intégrées.
//• Énoncé :
//• Déclarer une variable string avec une phrase;
//• Afficher la phrase en majuscules (ToUpper());
//• Remplacer un mot par un autre (Replace());
//• Afficher le nombre de caractères (Length);
void Exercice3()
{
    Console.WriteLine("=== Exercice 3 ===");
    string phrase = "Bonjour le monde de la programmation";
    Console.WriteLine($"Majuscules : {phrase.ToUpper()}");
    Console.WriteLine($"Remplacement : {phrase.Replace("monde", "univers")}");
    Console.WriteLine($"Nombre de caractères : {phrase.Length}");
    Console.WriteLine();
}

//• Exercice 4 – Classes et objets
//• Objectif : Créer et utiliser une classe simple.
//• Énoncé :
//• Créer une classe Produit avec propriétés Nom et Prix;
//• Ajouter une méthode Afficher() qui affiche « Nom : Prix $ »;
//• Dans Main, créer un objet Produit et appeler Afficher().
void Exercice4()
{
    Console.WriteLine("=== Exercice 4 ===");
    Produit produit = new Produit("Ordinateur", 999.99m);
    produit.Afficher();
    Console.WriteLine();
}

//• Exercice 5 – Encapsulation
//• Objectif : Protéger les données avec des modificateurs d'accès.
//• Énoncé :
//• Créer une classe CompteBancaire avec :
//• Champ privé solde initialisé à 100;
//• Méthode publique AfficherSolde();
//• Méthode publique Deposer(decimal montant) qui ajoute au solde;
//• Dans Main, créer un compte, déposer 50, afficher le solde.
void Exercice5()
{
    Console.WriteLine("=== Exercice 5 ===");
    CompteBancaire compte = new CompteBancaire();
    compte.Deposer(50);
    compte.AfficherSolde();
    Console.WriteLine();
}

//• Exercice 6 - Tableaux + Boucles imbriquées + Transformations
//• Objectif : Parcourir et transformer une matrice (tableau 2D).
//• Énoncé :
//• Créer un tableau 2D int[,] de taille 3 × 3 contenant les valeurs de votre choix;
//• Calculer et afficher :
//• La somme de chaque ligne;
//• La somme de chaque colonne;
//• La diagonale principale et sa somme;
//• Multiplier tous les éléments impairs par 2 (modifier directement dans le tableau);
//• Afficher le tableau final.
void Exercice6()
{
    Console.WriteLine("=== Exercice 6 ===");
    int[,] matrice = {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
    };

    // Somme de chaque ligne
    for (int i = 0; i < 3; i++)
    {
        int sommeLigne = 0;
        for (int j = 0; j < 3; j++)
        {
            sommeLigne += matrice[i, j];
        }
        Console.WriteLine($"Somme ligne {i + 1} : {sommeLigne}");
    }

    // Somme de chaque colonne
    for (int j = 0; j < 3; j++)
    {
        int sommeColonne = 0;
        for (int i = 0; i < 3; i++)
        {
            sommeColonne += matrice[i, j];
        }
        Console.WriteLine($"Somme colonne {j + 1} : {sommeColonne}");
    }

    // Diagonale principale
    int sommeDiagonale = 0;
    Console.Write("Diagonale principale : ");
    for (int i = 0; i < 3; i++)
    {
        Console.Write($"{matrice[i, i]} ");
        sommeDiagonale += matrice[i, i];
    }
    Console.WriteLine($"\nSomme diagonale : {sommeDiagonale}");

    // Multiplier les impairs par 2
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (matrice[i, j] % 2 != 0)
            {
                matrice[i, j] *= 2;
            }
        }
    }

    // Afficher le tableau final
    Console.WriteLine("Tableau final :");
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{matrice[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

//• Exercice 7 - Collections avancées (Dictionary + HashSet)
//• Objectif : Combiner plusieurs collections pour filtrer et analyser des données
//• Énoncé : 
//• Créer un Dictionary<string, int> représentant un inventaire (Produit → Quantité);
//• Créer un HashSet<string> contenant une liste de produits discontinués;
//• Retirer du dictionnaire tous les produits présents dans le HashSet (parcourir proprement sans modifier pendant l'itération);
//• Ajouter un nouveau produit si sa clé n'existe pas (utiliser ContainsKey);
//• Afficher:
//• Le produit ayant la plus grande quantité;
//• Le nombre total d'articles (somme des quantités).
void Exercice7()
{
    Console.WriteLine("=== Exercice 7 ===");
    Dictionary<string, int> inventaire = new Dictionary<string, int>
    {
        { "Pommes", 50 },
        { "Bananes", 30 },
        { "Oranges", 75 },
        { "Poires", 20 }
    };

    HashSet<string> discontinues = ["Bananes", "Poires"];

    // Retirer les produits discontinués
    List<string> aSupprimer = new List<string>();
    foreach (var produit in inventaire.Keys)
    {
        if (discontinues.Contains(produit))
        {
            aSupprimer.Add(produit);
        }
    }
    foreach (var produit in aSupprimer)
    {
        inventaire.Remove(produit);
    }

    // Ajouter un nouveau produit
    string nouveauProduit = "Mangues";
    if (!inventaire.ContainsKey(nouveauProduit))
    {
        inventaire.Add(nouveauProduit, 40);
    }

    // Produit avec la plus grande quantité
    var maxProduit = inventaire.OrderByDescending(p => p.Value).First();
    Console.WriteLine($"Plus grande quantité : {maxProduit.Key} ({maxProduit.Value})");

    // Total d'articles
    int totalArticles = inventaire.Values.Sum();
    Console.WriteLine($"Nombre total d'articles : {totalArticles}");
    Console.WriteLine();
}

//• Exercice 8 - Chaînes + StringBuilder + Parsing
//• Objectif : Manipuler, découper et reconstruire du texte efficacement
//• Énoncé :
//• Déclarer une chaîne contenant :"Alice, Bob, Charles, David, Emma«
//• Convertir cette chaîne en List (via Split → ToList());
//• Retirer tous les prénoms de plus de 4 lettres;
//• Recréer une seule chaîne formatée avec un StringBuilder, sous cette forme :"Liste finale : 
//Alice, Bob, Emma.«
//• Afficher :
//• Le nombre initial de prénoms;
//• Le nombre final;
//• La chaîne finale produite par le StringBuilder.
void Exercice8()
{
    Console.WriteLine("=== Exercice 8 ===");
    string chaine = "Alice, Bob, Charles, David, Emma";
    List<string> prenoms = chaine.Split(", ").ToList();
    int nombreInitial = prenoms.Count;

    prenoms.RemoveAll(p => p.Length > 4);

    StringBuilder sb = new StringBuilder();
    sb.Append("Liste finale : ");
    sb.Append(string.Join(", ", prenoms));
    sb.Append(".");

    Console.WriteLine($"Nombre initial : {nombreInitial}");
    Console.WriteLine($"Nombre final : {prenoms.Count}");
    Console.WriteLine(sb.ToString());
    Console.WriteLine();
}

//• Exercice 9 - Classes, héritage et polymorphisme
//• Objectif : Créer une hiérarchie de classes avec méthodes virtuelles
//• Énoncé :
//• Créer une classe abstraite Animal contenant :
//• Une propriété Nom;
//• Un constructeur;
//• Une méthode abstraite FaireSon();
//• Créer 2 classes dérivées Chien et Chat :
//• Chien.FaireSon() affiche: "Wouf !";
//• Chat.FaireSon() affiche: "Miaou !";
//• Dans Main :
//• Créer une List<Animal>;
//• Ajouter un Chien et un Chat;
//• Parcourir la liste et appeler FaireSon() sur chaque objet (polymorphisme).
void Exercice9()
{
    Console.WriteLine("=== Exercice 9 ===");
    List<Animal> animaux = new List<Animal>
    {
        new Chien("Rex"),
        new Chat("Minou")
    };

    foreach (var animal in animaux)
    {
        animal.FaireSon();
    }
    Console.WriteLine();
}

//• Exercice 10 – Encapsulation + Collections + Objets
//• Objectif : Gérer une collection d'objets avec protection des données
//• Énoncé :
//• Créer une classe Panier contenant :
//• Une List privée;
//• Une méthode publique AjouterProduit(Produit p);
//• Une méthode publique Total() retournant la somme des prix;
//• Une méthode publique Afficher() listant tous les produits;
//• Modifier la classe Produit précédente pour ajouter :
//• Un prix privé;
//• Un getter GetPrix();
//• Dans Main :
//• Créer un Panier;
//• Ajouter 3 produits;
//• Afficher le total final et le contenu du panier.
void Exercice10()
{
    Console.WriteLine("=== Exercice 10 ===");
    Panier panier = new Panier();
    panier.AjouterProduit(new ProduitAvecPrixPrive("Clavier", 49.99m));
    panier.AjouterProduit(new ProduitAvecPrixPrive("Souris", 29.99m));
    panier.AjouterProduit(new ProduitAvecPrixPrive("Écran", 299.99m));

    panier.Afficher();
    Console.WriteLine($"Total : {panier.Total()} $");
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
