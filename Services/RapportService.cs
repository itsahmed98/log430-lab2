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

    public IEnumerable<PerformanceMagasin> ObtenirPerformancesMagasins()
    {
        return _context.Magasins
            .Select(m => new PerformanceMagasin
            {
                Magasin = m.Nom,
                NombreDeVentes = _context.Ventes.Count(v => v.MagasinId == m.Id),
                TotalMontantVentes = _context.Ventes
                    .Where(v => v.MagasinId == m.Id)
                    .Sum(v => v.Total),

                ProduitLePlusVendu = _context.LignesVente
                    .Where(l => l.Vente.MagasinId == m.Id)
                    .GroupBy(l => l.Produit.Nom)
                    .OrderByDescending(g => g.Sum(l => l.Quantite))
                    .Select(g => g.Key)
                    .FirstOrDefault()
            }).ToList();
    }
}
