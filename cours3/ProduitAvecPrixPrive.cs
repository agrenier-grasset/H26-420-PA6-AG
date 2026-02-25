using System;

class ProduitAvecPrixPrive
{
    public string Nom { get; set; }
    private decimal prix;

    public ProduitAvecPrixPrive(string nom, decimal prix)
    {
        Nom = nom;
        this.prix = prix;
    }

    public decimal GetPrix()
    {
        return prix;
    }

    public void Afficher()
    {
        Console.WriteLine($"{Nom} : {prix} $");
    }
}
