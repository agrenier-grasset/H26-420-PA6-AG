class ServicePaiement
{
    public void TraiterPaiement(string montantStr)
    {
        try
        {
            decimal montant = decimal.Parse(montantStr);
            Console.WriteLine($"Paiement de {montant} $ traité avec succès.");
        }
        catch (FormatException ex)
        {
            throw new ErreurTechniqueException("Erreur lors du traitement du paiement.", ex);
        }
    }
}
