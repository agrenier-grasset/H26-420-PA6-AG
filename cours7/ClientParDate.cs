public class ClientParDate : IComparer<Client>
{
    public int Compare(Client? x, Client? y)
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

        return DateTime.Compare(x.DateInscription, y.DateInscription);
    }
}
