namespace MagasinMVC.Models;

/// <summary>
/// Représente un magasin dans le système de gestion de magasin.
/// </summary>
public class Magasin
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Quartier { get; set; }

    public ICollection<Produit> Produits { get; set; }
}
