namespace cours6
{
    public class ComparerClientId : IComparer<Client>
    {
        public int Compare(Client? x, Client? y)
        {
            if (x == null || y == null) return 0;
            return x.Id.CompareTo(y.Id);
        }
    }
}
