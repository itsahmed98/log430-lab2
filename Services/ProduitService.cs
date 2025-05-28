using MagasinMVC.Models;

namespace MagasinMVC.Services;

public class ProduitService
{
    private readonly MagasinContext _context;

    public ProduitService(MagasinContext context)
    {
        _context = context;
    }

    public List<Produit> ObtenirTousLesProduits()
    {
        return _context.Produits.ToList();
    }

    public void Reapprovisionner(int idProduit, int quantite)
    {
        var produit = _context.Produits.FirstOrDefault(p => p.Id == idProduit);
        if (produit != null)
        {
            produit.QuantiteStock += quantite;
            _context.SaveChanges();
        }
    }
}
