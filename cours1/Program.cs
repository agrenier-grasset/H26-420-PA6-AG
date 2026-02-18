// ============================================
// Programme d'exercices C# - Entrée/Sortie et Commentaires
// ============================================

//========================================================================
// Exercice 1 : Entrée et sortie en console​
//========================================================================
// Objectif : Créer un programme qui demande à l'utilisateur son nom et 
//            son âge, puis affiche un message personnalisé.​
//========================================================================
// Énoncé:​
// Demandez à l'utilisateur de saisir son nom.​
// Demandez à l'utilisateur de saisir son âge.​
// Affichez un message sous la forme :​
// "Bonjour [nom], vous avez [âge] ans."
//========================================================================

// Affichage d'un message de bienvenue à l'utilisateur
Console.WriteLine("=== Exercice 1 : Informations personnelles ===");
Console.WriteLine();

// Demander le nom de l'utilisateur
Console.Write("Veuillez entrer votre nom : ");
// La méthode ReadLine() lit l'entrée de l'utilisateur jusqu'à ce qu'il appuie sur Entrée
// Le résultat est stocké dans la variable 'nom' de type string
string? nom = Console.ReadLine();

// Demander l'âge de l'utilisateur avec validation
// Déclaration de la variable qui contiendra l'âge validé
int age;
// Boucle de validation pour s'assurer que l'utilisateur entre un nombre entier valide
while (true)
{
    // Afficher le message de demande
    Console.Write("Veuillez entrer votre âge : ");
    
    // Lire l'entrée de l'utilisateur sous forme de chaîne
    string? saisie = Console.ReadLine();
    
    // TryParse tente de convertir la chaîne en entier
    // - Si la conversion réussit, elle retourne true et stocke le résultat dans 'age'
    // - Si la conversion échoue, elle retourne false (pas d'exception levée)
    // - Le mot-clé 'out' permet à TryParse de retourner la valeur convertie
    if (int.TryParse(saisie, out age))
    {
        // La conversion a réussi, on sort de la boucle
        break;
    }
    else
    {
        // La conversion a échoué, on affiche un message d'erreur
        // La boucle continue et redemande une saisie valide
        Console.WriteLine("Erreur : Veuillez entrer un nombre entier valide.");
    }
}

// Afficher le message personnalisé avec les informations saisies
// Nous utilisons l'interpolation de chaînes (avec $) pour insérer les variables
Console.WriteLine();
Console.WriteLine($"Bonjour {nom}, vous avez {age} ans.");

// Ajouter une ligne vide pour séparer les exercices
Console.WriteLine();
Console.WriteLine();


//========================================================================
// Exercice 2 : Utilisation des commentaires​
//========================================================================
// Objectif : Ajouter des commentaires appropriés dans un programme 
//            pour expliquer son fonctionnement.​
//========================================================================
// Énoncé:​
// Écrivez un programme qui calcule la somme de deux nombres entiers.​
// Ajoutez des commentaires pour :​
// Expliquer la déclaration des variables.​
// Décrire la logique de calcul.​
// Documenter la méthode utilisée avec des commentaires XML.
//========================================================================

// Affichage du titre de l'exercice
Console.WriteLine("=== Exercice 2 : Calcul de la somme de deux nombres ===");
Console.WriteLine();

// Appel de la méthode qui calcule et affiche la somme
CalculerSomme();


/// <summary>
/// Méthode qui demande deux nombres entiers à l'utilisateur,
/// calcule leur somme et affiche le résultat.
/// </summary>
/// <remarks>
/// Cette méthode illustre :
/// - La déclaration de variables
/// - La conversion de types
/// - L'utilisation d'opérateurs arithmétiques
/// - L'affichage formaté avec interpolation de chaînes
/// </remarks>
static void CalculerSomme()
{
    // ============================================
    // SECTION 1 : Déclaration et initialisation des variables
    // ============================================
    
    // Déclaration de la variable 'premierNombre' de type entier (int)
    // Cette variable stockera le premier nombre saisi par l'utilisateur
    // Type int : entier signé sur 32 bits (plage : -2,147,483,648 à 2,147,483,647)
    int premierNombre;
    
    // Déclaration de la variable 'deuxiemeNombre' de type entier (int)
    // Cette variable stockera le deuxième nombre saisi par l'utilisateur
    int deuxiemeNombre;
    
    // Déclaration de la variable 'somme' de type entier (int)
    // Cette variable contiendra le résultat de l'addition des deux nombres
    int somme;
    
    
    // ============================================
    // SECTION 2 : Saisie des données par l'utilisateur avec validation
    // ============================================
    
    // Saisie du premier nombre avec validation
    // Boucle while infinie qui continue jusqu'à ce qu'une entrée valide soit fournie
    while (true)
    {
        // Demander à l'utilisateur de saisir le premier nombre
        Console.Write("Entrez le premier nombre entier : ");
        
        // Lire l'entrée de l'utilisateur sous forme de chaîne
        string? saisie = Console.ReadLine();
        
        // TryParse est une méthode sécurisée qui tente de convertir une chaîne en entier
        // Avantages de TryParse par rapport à Convert.ToInt32() :
        // - Ne lève pas d'exception en cas d'échec (meilleure performance)
        // - Retourne un booléen indiquant le succès ou l'échec
        // - Utilise le mot-clé 'out' pour retourner la valeur convertie
        if (int.TryParse(saisie, out premierNombre))
        {
            // La conversion a réussi, on sort de la boucle avec 'break'
            break;
        }
        else
        {
            // La conversion a échoué (texte non numérique, caractères spéciaux, etc.)
            // On affiche un message d'erreur et la boucle recommence
            Console.WriteLine("Erreur : Veuillez entrer un nombre entier valide.");
        }
    }
    
    // Saisie du deuxième nombre avec validation
    // Même logique que pour le premier nombre
    while (true)
    {
        // Demander à l'utilisateur de saisir le deuxième nombre
        Console.Write("Entrez le deuxième nombre entier : ");
        
        // Lire l'entrée de l'utilisateur
        string? saisie = Console.ReadLine();
        
        // Tenter de convertir la saisie en entier
        // Si réussi, 'deuxiemeNombre' contient la valeur et TryParse retourne true
        if (int.TryParse(saisie, out deuxiemeNombre))
        {
            // Sortir de la boucle, valeur valide obtenue
            break;
        }
        else
        {
            // Afficher un message d'erreur si la conversion échoue
            Console.WriteLine("Erreur : Veuillez entrer un nombre entier valide.");
        }
    }
    
    
    // ============================================
    // SECTION 3 : Logique de calcul
    // ============================================
    
    // Calcul de la somme des deux nombres
    // L'opérateur '+' additionne les deux valeurs entières
    // Le résultat est stocké dans la variable 'somme'
    somme = premierNombre + deuxiemeNombre;
    
    
    // ============================================
    // SECTION 4 : Affichage du résultat
    // ============================================
    
    // Afficher une ligne vide pour améliorer la lisibilité
    Console.WriteLine();
    
    // Afficher le résultat du calcul
    // Utilisation de l'interpolation de chaînes ($"...") pour insérer les valeurs
    // des variables directement dans le texte
    Console.WriteLine($"La somme de {premierNombre} + {deuxiemeNombre} = {somme}");
    
    // Message de confirmation final
    Console.WriteLine();
    Console.WriteLine("Calcul terminé avec succès!");
}