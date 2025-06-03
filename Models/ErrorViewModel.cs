namespace MagasinMVC.Models;

/// <summary>
/// Représente un modèle de vue pour les erreurs dans l'application.
/// </summary>
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
