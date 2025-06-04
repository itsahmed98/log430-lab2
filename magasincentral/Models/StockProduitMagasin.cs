namespace magasincentral.Models;

/// <summary>
/// Représente la quantité locale d’un produit dans un magasin.
/// </summary>
public class StockProduitMagasin
{
    public int Id { get; set; }

    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;

    public int MagasinId { get; set; }
    public Magasin Magasin { get; set; } = null!;

    public int Quantite { get; set; }
}
