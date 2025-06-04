using Microsoft.EntityFrameworkCore;
using MagasinMVC.Models;

public class MagasinContext : DbContext
{
    public MagasinContext(DbContextOptions<MagasinContext> options) : base(options) { }

    public DbSet<Produit> Produits { get; set; }
    public DbSet<Magasin> Magasins { get; set; }
    public DbSet<Vente> Ventes { get; set; }
    public DbSet<LigneVente> LignesVente { get; set; }
}