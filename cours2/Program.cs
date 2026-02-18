// ============================================
// Programme d'exercices C# - Types, Opérateurs et Boucles
// ============================================

//========================================================================
// Exercice 1 : Types et Opérateurs Logiques avec Court-Circuit
//========================================================================
// Objectif : Manipuler les types et les opérateurs logiques avec court-circuit
//========================================================================
// Énoncé: ​
// Demander à l’utilisateur de saisir un entier (ex. via Console.ReadLine() puis conversion).​
// Stocker la valeur dans une variable int nommée nombre.​
// Afficher : 
// « Petit » si nombre < 0 ou 0 <= nombre < 10.​
// « Moyen » si 10 <= nombre <= 99.​
// « Grand » si nombre >= 100.​
// Contrainte : faire au moins une condition composée utilisant && ou || (court‑circuit),
// et au moins un test d’égalité == ou de différence != (par ex. traiter le cas nombre == 42 avec un message spécial).​
// Bonus : utiliser l’opérateur conditionnel ternaire ?: pour construire la chaîne à afficher en une expression, puis l’imprimer avec Console.WriteLine.
//========================================================================
Console.WriteLine("========================================");
Console.WriteLine("EXERCICE 1 : Classification de nombres");
Console.WriteLine("========================================");
Console.WriteLine();

// Déclaration de la variable qui stockera le nombre saisi
int nombre;

// Boucle de validation pour s'assurer que l'utilisateur entre un entier valide
while (true)
{
    // Demander à l'utilisateur de saisir un nombre entier
    Console.Write("Veuillez entrer un nombre entier : ");
    
    // Lire l'entrée de l'utilisateur sous forme de chaîne
    string? saisie = Console.ReadLine();
    
    // TryParse : méthode sécurisée pour convertir une chaîne en entier
    // Retourne true si la conversion réussit, false sinon (pas d'exception)
    if (int.TryParse(saisie, out nombre))
    {
        // Conversion réussie, sortir de la boucle
        break;
    }
    else
    {
        // Conversion échouée, afficher un message d'erreur et recommencer
        Console.WriteLine("Erreur : Veuillez entrer un nombre entier valide.");
    }
}

// ============================================
// Traitement du cas spécial : nombre == 42
// ============================================
// Test d'égalité (==) pour vérifier si c'est le nombre magique
if (nombre == 42)
{
    Console.WriteLine("Wow ! Vous avez trouvé la réponse à la Grande Question sur la vie, l'univers et le reste !");
}

// ============================================
// Classification du nombre avec opérateurs logiques
// ============================================

// Utilisation de l'opérateur ternaire conditionnel (? :) pour construire le message
// Syntaxe : condition ? valeur_si_vrai : valeur_si_faux
// Les opérateurs ternaires peuvent être imbriqués pour tester plusieurs conditions

string classification = 
    // Condition composée avec l'opérateur OU (||) - court-circuit
    // Si la première partie est vraie (nombre < 0), la deuxième n'est pas évaluée
    (nombre < 0 || nombre < 10) ? "Petit" :
    // Condition composée avec l'opérateur ET (&&) - court-circuit
    // Les deux parties doivent être vraies pour que l'ensemble soit vrai
    (nombre >= 10 && nombre <= 99) ? "Moyen" :
    // Si aucune des conditions précédentes n'est vraie
    "Grand";

// Afficher le résultat de la classification
Console.WriteLine($"Le nombre {nombre} est classé comme : {classification}");
Console.WriteLine();
Console.WriteLine();


//========================================================================
// Exercice 2 : Boucle FOR avec Continue et Break
//========================================================================
// Objectif : Maîtriser for, les opérateurs arithmétiques et continue/break
//========================================================================
// Énoncé: 
// Écrire une boucle for qui parcourt les entiers de -30 à 60 inclus.​
// Afficher uniquement les multiples de 6.​
// Ignorer (ne pas afficher) les valeurs qui sont aussi multiples de 9 (utiliser continue).​
// Arrêter la boucle (avec break) dès que vous affichez une valeur strictement supérieure à 42.​
// Bonus : compter combien de nombres ont été effectivement affichés et afficher ce total à la fin.
//========================================================================
Console.WriteLine("========================================");
Console.WriteLine("EXERCICE 2 : Multiples de 6");
Console.WriteLine("========================================");
Console.WriteLine();

// Compteur pour le nombre de valeurs affichées (bonus)
int compteur = 0;

// Boucle for qui parcourt les entiers de -30 à 60 inclus
// Syntaxe : for (initialisation; condition; incrément)
for (int i = -30; i <= 60; i++)
{
    // Vérifier si i est un multiple de 6
    // L'opérateur modulo (%) retourne le reste de la division
    // Si i % 6 == 0, alors i est divisible par 6 sans reste
    if (i % 6 == 0)
    {
        // Vérifier si i est AUSSI un multiple de 9
        // Si oui, on l'ignore (ne pas afficher) avec continue
        if (i % 9 == 0)
        {
            // continue : passe immédiatement à l'itération suivante de la boucle
            // Le code après continue n'est pas exécuté pour cette itération
            continue;
        }
        
        // Afficher le nombre (c'est un multiple de 6, mais pas de 9)
        Console.WriteLine($"  {i}");
        
        // Incrémenter le compteur (bonus)
        compteur++;
        
        // Si la valeur affichée est strictement supérieure à 42, arrêter la boucle
        if (i > 42)
        {
            // break : sort immédiatement de la boucle
            // Aucune itération supplémentaire n'est effectuée
            break;
        }
    }
}

// Afficher le total de nombres affichés (bonus)
Console.WriteLine();
Console.WriteLine($"Nombre total de valeurs affichées : {compteur}");
Console.WriteLine();
Console.WriteLine();


//========================================================================
// Exercice 3 : Boucle FOR avec Conditions et Conversions de Type
//========================================================================
// Objectif : Combiner for, conditions et opérations arithmétiques
//========================================================================
// Énoncé: ​
// Calculer et afficher la somme de tous les entiers entre 1 et 200 qui sont divisibles par 3 ou par 5, mais pas les deux en même temps (exclusif, logique de type « XOR » que vous pouvez écrire avec &&/|| et !).​
// Afficher aussi combien de nombres ont été additionnés.​
// Calculer et afficher la moyenne comme un double (attention à la conversion pour éviter la division entière).​
// Bonus : afficher la différence entre (somme des multiples de 3) et (somme des multiples de 5) sur l’intervalle, pour vérifier votre compréhension des filtres.
//========================================================================
Console.WriteLine("========================================");
Console.WriteLine("EXERCICE 3 : Somme avec XOR logique");
Console.WriteLine("========================================");
Console.WriteLine();

// Variables pour stocker les résultats
int somme = 0;              // Somme totale (divisible par 3 XOR 5)
int compte = 0;             // Nombre de valeurs additionnées
int sommeMultiples3 = 0;    // Bonus : somme des multiples de 3 uniquement
int sommeMultiples5 = 0;    // Bonus : somme des multiples de 5 uniquement

// Boucle for qui parcourt les entiers de 1 à 200 inclus
for (int i = 1; i <= 200; i++)
{
    // Vérifier si i est divisible par 3
    bool divisiblePar3 = (i % 3 == 0);
    
    // Vérifier si i est divisible par 5
    bool divisiblePar5 = (i % 5 == 0);
    
    // XOR logique (exclusif) : vrai si une condition est vraie mais pas les deux
    // Implémentation avec opérateurs logiques : (A && !B) || (!A && B)
    // Signifie : (divisible par 3 ET PAS par 5) OU (PAS par 3 ET divisible par 5)
    bool xorCondition = (divisiblePar3 && !divisiblePar5) || (!divisiblePar3 && divisiblePar5);
    
    // Si la condition XOR est vraie, ajouter i à la somme
    if (xorCondition)
    {
        somme += i;  // Équivalent à : somme = somme + i;
        compte++;    // Incrémenter le compteur
    }
    
    // Bonus : calculer les sommes séparées pour les multiples de 3 et de 5
    if (divisiblePar3)
    {
        sommeMultiples3 += i;
    }
    if (divisiblePar5)
    {
        sommeMultiples5 += i;
    }
}

// Calculer la moyenne comme un double
// IMPORTANT : Conversion explicite pour éviter la division entière
// Si on fait compte / somme directement, le résultat serait tronqué (partie entière seulement)
// En convertissant somme en double, on force une division à virgule flottante
double moyenne = (double)somme / compte;

// Afficher les résultats
Console.WriteLine($"Somme des nombres divisibles par 3 XOR 5 : {somme}");
Console.WriteLine($"Nombre de valeurs additionnées : {compte}");
Console.WriteLine($"Moyenne : {moyenne:F2}");  // F2 : format avec 2 décimales
Console.WriteLine();

// Bonus : afficher la différence entre les deux sommes
int difference = sommeMultiples3 - sommeMultiples5;
Console.WriteLine("--- BONUS ---");
Console.WriteLine($"Somme des multiples de 3 : {sommeMultiples3}");
Console.WriteLine($"Somme des multiples de 5 : {sommeMultiples5}");
Console.WriteLine($"Différence (multiples de 3 - multiples de 5) : {difference}");
Console.WriteLine();
Console.WriteLine();


//========================================================================
// Exercice 4 : Boucle WHILE avec Conditions sur Chaînes
//========================================================================
// Objectif : Exploiter while, les conditions sur chaînes et les opérateurs logiques
//========================================================================
// Énoncé: ​
// Demander à l’utilisateur d’entrer du texte en boucle.​
// Finir seulement lorsqu’il saisit exactement STOP (en majuscules).​
// Pour toute autre saisie : ​
// Afficher la longueur de la phrase sans les espaces en début/fin (Trim()).​
// Indiquer si la phrase contient le mot « C# » (respecter la casse : Contains("C#")).​
// Contrainte : traiter explicitement le cas de la chaîne vide ("") : afficher « Saisie vide » et continuer la boucle.​
// Bonus : afficher le nombre de voyelles (a, e, i, o, u, y en minuscules/majuscules) présentes dans la saisie trimmée.​
// Astuce : vous pouvez itérer les caractères avec foreach (char c in texte) et utiliser des conditions composées (ex. c == 'a' || c == 'A' || …).
//========================================================================
Console.WriteLine("========================================");
Console.WriteLine("EXERCICE 4 : Analyse de texte");
Console.WriteLine("========================================");
Console.WriteLine("Entrez du texte (tapez STOP pour terminer)");
Console.WriteLine();

// Boucle while infinie - sortira uniquement avec break
while (true)
{
    // Demander à l'utilisateur d'entrer du texte
    Console.Write("> ");
    
    // Lire l'entrée de l'utilisateur
    // Le ? indique que la variable peut être null (nullable)
    string? saisieTexte = Console.ReadLine();
    
    // Vérifier si l'utilisateur a saisi exactement "STOP" (en majuscules)
    // == : opérateur d'égalité pour les chaînes (sensible à la casse)
    if (saisieTexte == "STOP")
    {
        // Sortir de la boucle
        Console.WriteLine("Programme terminé.");
        break;
    }
    
    // Trim() : enlève les espaces en début et fin de chaîne
    // Cela nous donne une version nettoyée du texte pour l'analyse
    string texteNettoye = saisieTexte?.Trim() ?? "";
    
    // Traiter explicitement le cas de la chaîne vide
    // Après Trim(), une chaîne ne contenant que des espaces devient ""
    if (texteNettoye == "")
    {
        Console.WriteLine("  → Saisie vide");
        Console.WriteLine();
        continue;  // Passer à l'itération suivante
    }
    
    // Afficher la longueur de la phrase (après Trim)
    // Length : propriété qui retourne le nombre de caractères dans une chaîne
    Console.WriteLine($"  → Longueur (sans espaces de début/fin) : {texteNettoye.Length} caractères");
    
    // Vérifier si la phrase contient "C#"
    // Contains() : méthode qui vérifie si une sous-chaîne est présente
    // Respecte la casse (C# ≠ c# ≠ C# avec espace)
    bool contientCSharp = texteNettoye.Contains("C#");
    
    // Opérateur ternaire pour afficher le résultat
    string messageCSharp = contientCSharp ? "OUI" : "NON";
    Console.WriteLine($"  → Contient 'C#' : {messageCSharp}");
    
    // ============================================
    // BONUS : Compter les voyelles
    // ============================================
    
    // Compteur de voyelles initialisé à 0
    int nombreVoyelles = 0;
    
    // foreach : boucle qui parcourt tous les éléments d'une collection
    // Ici, elle parcourt tous les caractères (char) de la chaîne texteNettoye
    foreach (char c in texteNettoye)
    {
        // Condition composée avec l'opérateur OU (||)
        // Vérifie si le caractère est une voyelle (minuscule OU majuscule)
        // Le court-circuit s'arrête dès qu'une condition est vraie
        if (c == 'a' || c == 'A' ||
            c == 'e' || c == 'E' ||
            c == 'i' || c == 'I' ||
            c == 'o' || c == 'O' ||
            c == 'u' || c == 'U' ||
            c == 'y' || c == 'Y')
        {
            nombreVoyelles++;
        }
    }
    
    // Afficher le nombre de voyelles trouvées (bonus)
    Console.WriteLine($"  → Nombre de voyelles : {nombreVoyelles}");
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine();


//========================================================================
// Exercice 5 : Double Boucle Imbriquée - Table de Multiplication
//========================================================================
// Objectif : double boucle imbriquée (for dans for) + mise en forme et test de conditions.
//========================================================================
// Énoncé: ​
// Afficher la table de multiplication de 1 à 12 sous forme de tableau aligné (largeur fixe, p. ex. Console.Write($"{val,4}")).​
// Mettre en évidence (par des crochets [] autour du nombre) les carrés parfaits (1, 4, 9, 16, …, 144).​
// Contrainte : n’imprimer que la demi‑table supérieure (triangulaire) où col >= ligne.​
// Bonus A : ajouter une ligne d’en‑têtes et une colonne d’index (1..12) correctement alignées.​
// Bonus B : colorier les multiples de 10 en changeant temporairement la couleur (ex. Console.ForegroundColor = ConsoleColor.Yellow; puis réinitialiser).​
// (Si tu préfères rester strictement dans « console + texte », garde uniquement les crochets pour la mise en évidence.)
//========================================================================
Console.WriteLine("========================================");
Console.WriteLine("EXERCICE 5 : Table de multiplication");
Console.WriteLine("========================================");
Console.WriteLine("(Demi-table triangulaire avec carrés parfaits en évidence)");
Console.WriteLine();

// ============================================
// BONUS A : Afficher la ligne d'en-têtes
// ============================================

// Afficher un espace pour aligner avec la colonne d'index
Console.Write("    ");  // 4 espaces pour l'alignement

// Boucle pour afficher les numéros de colonnes (1 à 12)
for (int col = 1; col <= 12; col++)
{
    // {col,4} : format avec largeur de 4 caractères, aligné à droite
    Console.Write($"{col,4}");
}
// Nouvelle ligne après les en-têtes
Console.WriteLine();

// Afficher une ligne de séparation pour la lisibilité
Console.Write("    ");
for (int col = 1; col <= 12; col++)
{
    Console.Write("----");
}
Console.WriteLine();

// ============================================
// Boucles imbriquées pour la table de multiplication
// ============================================

// Boucle externe : parcourt les lignes (1 à 12)
for (int ligne = 1; ligne <= 12; ligne++)
{
    // BONUS A : Afficher l'index de ligne au début de chaque ligne
    // {ligne,2} : largeur de 2 caractères pour l'index
    Console.Write($"{ligne,2} |");
    
    // Boucle interne : parcourt les colonnes (1 à 12)
    for (int col = 1; col <= 12; col++)
    {
        // Contrainte : n'imprimer que la demi-table supérieure (triangulaire)
        // où col >= ligne (partie au-dessus de la diagonale incluse)
        if (col >= ligne)
        {
            // Calculer le produit de ligne × colonne
            int produit = ligne * col;
            
            // Vérifier si le produit est un carré parfait
            // Méthode : calculer la racine carrée, puis vérifier si elle est entière
            // Math.Sqrt() retourne un double, on le convertit en int
            int racine = (int)Math.Sqrt(produit);
            // Si racine² == produit, alors produit est un carré parfait
            bool estCarrePerfait = (racine * racine == produit);
            
            // BONUS B : Vérifier si le produit est un multiple de 10 pour la coloration
            bool estMultipleDe10 = (produit % 10 == 0 && produit != 0);
            
            // Si c'est un multiple de 10, changer la couleur
            if (estMultipleDe10)
            {
                // Sauvegarder la couleur actuelle pour pouvoir la restaurer
                ConsoleColor couleurOriginale = Console.ForegroundColor;
                // Changer la couleur en jaune pour les multiples de 10
                Console.ForegroundColor = ConsoleColor.Yellow;
                
                // Afficher le nombre avec ou sans crochets selon s'il est un carré parfait
                if (estCarrePerfait)
                {
                    // Format avec crochets pour les carrés parfaits
                    Console.Write($"[{produit,2}]");
                }
                else
                {
                    // Format normal avec 4 caractères
                    Console.Write($"{produit,4}");
                }
                
                // Restaurer la couleur originale
                Console.ForegroundColor = couleurOriginale;
            }
            else
            {
                // Cas normal (pas un multiple de 10)
                // Mettre en évidence les carrés parfaits avec des crochets []
                if (estCarrePerfait)
                {
                    // Les crochets ajoutent 2 caractères, donc on utilise 2 pour le nombre
                    // Format : [nombre] aligné sur 4 caractères au total
                    Console.Write($"[{produit,2}]");
                }
                else
                {
                    // Format normal : 4 caractères, aligné à droite
                    Console.Write($"{produit,4}");
                }
            }
        }
        else
        {
            // Partie inférieure du triangle (non affichée selon la contrainte)
            // Afficher des espaces pour maintenir l'alignement du tableau
            Console.Write("    ");
        }
    }
    
    // Nouvelle ligne après chaque ligne de la table
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("Légende : [XX] = carrés parfaits, en jaune = multiples de 10");
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("Tous les exercices sont terminés !");
Console.WriteLine("========================================");