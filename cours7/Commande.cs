public class Commande
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public decimal Montant { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime DateCommande { get; set; }
}
