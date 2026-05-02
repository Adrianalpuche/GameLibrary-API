using System;

namespace GameLibrary.Api.Models;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
    public required Genre Genre { get; set; }
    public required Developer Developer { get; set; }
    public DateTime ReleaseDate { get; set; }


}
