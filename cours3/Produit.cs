using System;

class Produit
{
    public string Nom { get; set; }
    public decimal Prix { get; set; }

    public Produit(string nom, decimal prix)
    {
        Nom = nom;
        Prix = prix;
    }

    public void Afficher()
    {
        Console.WriteLine($"{Nom} : {Prix} $");
    }

    public decimal GetPrix()
    {
        return Prix;
    }
}
