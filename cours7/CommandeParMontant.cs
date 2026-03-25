public class CommandeParMontant : IComparer<Commande>
{
    public int Compare(Commande? x, Commande? y)
    {
        if (ReferenceEquals(x, y))
        {
            return 0;
        }

        if (x is null)
        {
            return -1;
        }

        if (y is null)
        {
            return 1;
        }

        return x.Montant.CompareTo(y.Montant);
    }
}
