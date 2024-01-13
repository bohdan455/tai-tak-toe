using System.ComponentModel.DataAnnotations;

namespace Rest.Controllers;

public class MakeMoveRequest
{
    [Required]
    public string PlayerId { get; set; } = default!;

    [Required]
    public string BoardId { get; set; } = default!;

    [Required]
    public int X { get; set; }

    [Required]
    public int Y { get; set; }
}