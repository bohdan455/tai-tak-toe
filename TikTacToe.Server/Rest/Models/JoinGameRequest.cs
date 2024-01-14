using System.ComponentModel.DataAnnotations;

namespace Rest.Models;

public class JoinGameRequest
{
    [Required]
    public string BoardId { get; set; } = default!;
}