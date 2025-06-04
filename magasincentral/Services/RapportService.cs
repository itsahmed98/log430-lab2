using magasincentral.Models.ViewModels;

namespace magasincentral.Services;

/// <summary>
/// Service pour générer des rapports sur les ventes et les performances des magasins.
/// </summary>
public class RapportService
{
    /// <summary>
    /// Contexte de la base de données pour accéder aux données des magasins, ventes et produits.
    /// </summary>
    private readonly MagasinContext _context;

    /// <summary>
    /// Constructeur du service RapportService.
    /// </summary>
    /// <param name="context">Contexte de la base de données</param>
    public RapportService(MagasinContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Obtenir les ventes totales par magasin.
    /// </summary>
    /// <returns>Une liste des ventes totales</returns>
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

    /// <summary>
    /// Obtenir les produits les plus vendus.
    /// </summary>
    /// <returns>Une liste des produits les plus vendus</returns>
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

    /// <summary>
    /// Obtenir le stock de chaque produit dans le magasin.
    /// </summary>
    /// <returns>Une liste du stock</returns>
    public IEnumerable<StockProduit> ObtenirStockParProduit()
    {
        return _context.Produits
            .Select(p => new StockProduit
            {
                Produit = p.Nom,
                Stock = p.QuantiteStock
            }).ToList();
    }

    /// <summary>
    /// Obtenir les performances des magasins.
    /// </summary>
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
