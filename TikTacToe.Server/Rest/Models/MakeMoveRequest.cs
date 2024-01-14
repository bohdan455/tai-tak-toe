using System.ComponentModel.DataAnnotations;

namespace Rest.Models;

public class MakeMoveRequest
{
    [Required]
    public string PlayerId { get; set; } = default!;

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set; }
}