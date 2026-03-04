class Produit
{
    private decimal _prixUnitaire;
    private int _quantite;

    public string Nom { get; }

    public decimal PrixUnitaire
    {
        get { return _prixUnitaire; }
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Le prix doit être supérieur à 0.");
            _prixUnitaire = value;
        }
    }

    public int Quantite
    {
        get { return _quantite; }
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La quantité ne peut pas être négative.");
            _quantite = value;
        }
    }

    public decimal Total => PrixUnitaire * Quantite;

    public Produit(string nom, decimal prixUnitaire, int quantite)
    {
        Nom = nom;
        PrixUnitaire = prixUnitaire;
        Quantite = quantite;
    }
}
