using System;

namespace GameLibrary.Api.Dtos;

public class CreateGameDto
{
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
     public int GenreId { get; set; }
    public int DeveloperId { get; set; }
    public DateTime ReleaseDate { get; set; }

}
