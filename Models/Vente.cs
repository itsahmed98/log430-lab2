namespace MagasinMVC.Models;

/// <summary>
/// Représente une vente dans le système de gestion de magasin.
/// </summary>
public class Vente
{
    public int Id { get; set; }
    public DateTime DateVente { get; set; }
    public decimal Total { get; set; }

    public List<LigneVente> Lignes { get; set; } = new();

    public int MagasinId { get; set; }
    public Magasin Magasin { get; set; }
}
