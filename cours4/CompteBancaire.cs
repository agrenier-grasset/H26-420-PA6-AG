class CompteBancaire
{
    private decimal _solde;

    public decimal Solde
    {
        get { return _solde; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Le solde ne peut pas être négatif.");
            _solde = value;
        }
    }

    public void Retirer(decimal montant)
    {
        if (montant > _solde)
            throw new SoldeInsuffisantException("Solde insuffisant pour effectuer ce retrait.");
        _solde -= montant;
    }
}
