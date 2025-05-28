using Microsoft.EntityFrameworkCore;
using Models;

public class MagasinContext : DbContext
{
    public MagasinContext(DbContextOptions<MagasinContext> options) : base(options) { }

    public DbSet<Produit> Produits { get; set; }
}