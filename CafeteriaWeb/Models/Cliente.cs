using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    [Required]
    [StringLength(10, MinimumLength = 6)]
    public string Cedula { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public string Correo { get; set; }
}
