using System;
using GameLibrary.Api.Dtos;
using GameLibrary.Api.Models;

namespace GameLibrary.Api.Mappers;

public static class GameMappers
{
    public static GameDto ToGameDto(this Game GameModel)
    {
        return new GameDto
        {
            Id = GameModel.Id,
            Title = GameModel.Title,
            ImageUrl = GameModel.ImageUrl,
            Description = GameModel.Description,
            Genre = GameModel.Genre != null ? new GenreDto { Id = GameModel.Genre.Id, Name = GameModel.Genre.Name } : null,
            Developer = GameModel.Developer != null ? new DeveloperDto { Id = GameModel.Developer.Id, Name = GameModel.Developer.Name } : null,
            ReleaseDate = GameModel.ReleaseDate
        };
    }
        

}
