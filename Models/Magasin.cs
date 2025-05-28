namespace MagasinMVC.Models;

public class Magasin
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Quartier { get; set; }

    public ICollection<Produit> Produits { get; set; }
}
