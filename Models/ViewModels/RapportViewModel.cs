using System.Collections.Generic;

namespace MagasinMVC.Models.ViewModels;

public class RapportViewModel
{
    public IEnumerable<VenteParMagasin> VentesParMagasin { get; set; }
    public IEnumerable<ProduitVendu> ProduitsLesPlusVendus { get; set; }
    public IEnumerable<StockProduit> Stocks { get; set; }
}
