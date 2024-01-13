using System.ComponentModel.DataAnnotations;

namespace Rest.Controllers;

public class JoinGameRequest
{
    [Required]
    public string PlayerId { get; set; } = default!;

    [Required]
    public string BoardId { get; set; } = default!;
}