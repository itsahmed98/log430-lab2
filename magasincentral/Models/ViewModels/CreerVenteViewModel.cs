using Microsoft.AspNetCore.Mvc.Rendering;

namespace magasincentral.Models.ViewModels;

public class CreerVenteViewModel
{
    public int MagasinId { get; set; }
    public int ProduitId { get; set; }
    public int Quantite { get; set; }

    public List<SelectListItem> ListeMagasins { get; set; }
    public List<SelectListItem> ListeProduits { get; set; }
}
