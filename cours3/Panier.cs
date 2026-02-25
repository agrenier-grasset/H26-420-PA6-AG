using System;
using System.Collections.Generic;
using System.Linq;

class Panier
{
    private List<ProduitAvecPrixPrive> produits = new List<ProduitAvecPrixPrive>();

    public void AjouterProduit(ProduitAvecPrixPrive p)
    {
        produits.Add(p);
    }

    public decimal Total()
    {
        return produits.Sum(p => p.GetPrix());
    }

    public void Afficher()
    {
        Console.WriteLine("Contenu du panier :");
        foreach (var produit in produits)
        {
            produit.Afficher();
        }
    }
}
