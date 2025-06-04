namespace magasincentral.Models;

/// <summary>
/// Représente un modèle du produit dans le système de gestion de magasin.
/// </summary>
public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Categorie { get; set; }
    public decimal Prix { get; set; }
    public int QuantiteStock { get; set; }
}