namespace cours6
{
    public class ComparerClientNom : IComparer<Client>
    {
        public int Compare(Client? x, Client? y)
        {
            if (x == null || y == null) return 0;
            return string.Compare(x.Nom, y.Nom, StringComparison.OrdinalIgnoreCase);
        }
    }
}
