using MagasinMVC.Models.ViewModels;

namespace MagasinMVC.Services;

public class RapportService
{
    private readonly MagasinContext _context;

    public RapportService(MagasinContext context)
    {
        _context = context;
    }

    public IEnumerable<VenteParMagasin> ObtenirVentesParMagasin()
    {
        return _context.Magasins
            .Select(m => new VenteParMagasin
            {
                Magasin = m.Nom,
                TotalVentes = _context.Ventes
                    .Where(v => v.Id == m.Id)
                    .Sum(v => v.Total)
            }).ToList();
    }

    public IEnumerable<ProduitVendu> ObtenirProduitsLesPlusVendus()
    {
        return _context.LignesVente
            .GroupBy(l => l.Produit.Nom)
            .Select(g => new ProduitVendu
            {
                Produit = g.Key,
                QuantiteVendue = g.Sum(l => l.Quantite)
            })
            .OrderByDescending(p => p.QuantiteVendue)
            .Take(5)
            .ToList();
    }

    public IEnumerable<StockProduit> ObtenirStockParProduit()
    {
        return _context.Produits
            .Select(p => new StockProduit
            {
                Produit = p.Nom,
                Stock = p.QuantiteStock
            }).ToList();
    }

}
