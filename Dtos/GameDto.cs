using System;
using GameLibrary.Api.Models;

namespace GameLibrary.Api.Dtos;

public class GameDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
    public  GenreDto? Genre { get; set; }
    public  DeveloperDto? Developer { get; set; }
    public DateTime ReleaseDate { get; set; }


}
