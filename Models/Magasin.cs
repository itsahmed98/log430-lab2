using System.ComponentModel.DataAnnotations;

namespace MagasinMVC.Models;

/// <summary>
/// Représente un magasin dans le système.
/// Chaque magasin est associé à un quartier.
/// </summary>
public class Magasin
{
    /// <summary>
    /// Identifiant unique du magasin.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nom du magasin.
    /// </summary>
    [Required]
    public string Nom { get; set; }

    /// <summary>
    /// Quartier dans lequel se situe le magasin.
    /// </summary>
    public string Quartier { get; set; }
}
