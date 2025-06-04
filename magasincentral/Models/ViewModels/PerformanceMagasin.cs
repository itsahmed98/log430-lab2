namespace MagasinMVC.Models.ViewModels;

public class PerformanceMagasin
{
    public string Magasin { get; set; }
    public int NombreDeVentes { get; set; }
    public decimal TotalMontantVentes { get; set; }
    public string ProduitLePlusVendu { get; set; }
}
