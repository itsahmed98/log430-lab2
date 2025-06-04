using Microsoft.EntityFrameworkCore;
using magasincentral.Models;

/// <summary>
/// Contexte de la base de données pour l'application Magasin Central.
/// </summary>
public class MagasinContext : DbContext
{
    public MagasinContext(DbContextOptions<MagasinContext> options) : base(options) { }

    public DbSet<Produit> Produits { get; set; }
    public DbSet<Magasin> Magasins { get; set; }
    public DbSet<Vente> Ventes { get; set; }
    public DbSet<LigneVente> LignesVente { get; set; }
    public DbSet<StockProduitMagasin> StocksProduitsMagasins { get; set; }

}