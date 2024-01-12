using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class WinnerType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Name { get; set; } = default!;
}