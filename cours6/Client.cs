namespace cours6
{
    public class Client : IComparable<Client>
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }

        public int CompareTo(Client? other)
        {
            return this.Id.CompareTo(other?.Id);
        }
    }
}
