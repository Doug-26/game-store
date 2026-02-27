using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs;

public record UpdateGameDTO (
    [Required][StringLength(50)] string Name,
    [Range(1, 60)] int GenreId,
    [Range(1, 1000.00)] decimal Price,
    DateOnly ReleaseDate
);
