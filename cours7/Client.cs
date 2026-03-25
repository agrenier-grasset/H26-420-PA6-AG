public class Client : Entity, IComparable<Client>
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateInscription { get; set; }

    public int CompareTo(Client? other)
    {
        if (other is null)
        {
            return 1;
        }

        return string.Compare(Nom, other.Nom, StringComparison.OrdinalIgnoreCase);
    }
}
