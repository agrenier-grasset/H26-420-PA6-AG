using System;

class CompteBancaire
{
    private decimal solde = 100;

    public void AfficherSolde()
    {
        Console.WriteLine($"Solde : {solde} $");
    }

    public void Deposer(decimal montant)
    {
        solde += montant;
    }
}
