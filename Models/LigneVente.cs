namespace MagasinMVC.Models;

/// <summary>
/// Represente une ligne de vente dans le système de gestion de magasin.
/// </summary>
public class LigneVente
{
    public int Id { get; set; }
    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
    public int Quantite { get; set; }
    public decimal PrixUnitaire { get; set; }

    public int VenteId { get; set; }
    public Vente Vente { get; set; } = null!;
}