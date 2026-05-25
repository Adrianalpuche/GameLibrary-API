using System;
using GameLibrary.Api.Data;
using GameLibrary.Api.Dtos;
using GameLibrary.Api.Mappers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.controllers;


[Microsoft.AspNetCore.Mvc.Route("api/games")]
[ApiController]
public class GameController: ControllerBase
{
    private readonly GameLibraryContext _context;
    public GameController(GameLibraryContext context )
    {
        _context = context;
        
    }


    //* GET: api/games
    [HttpGet]
    public async Task<ActionResult> GamesList()
    {
        var games = (await _context.Games
            .Include(g => g.Genre)
            .Include(g => g.Developer)
            .ToListAsync())
            .Select(g => g.ToGameDto());

        return Ok(games);
    }

    //* GET: api/games/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult> GetGameById([FromRoute] int id)
    {
        var game = await _context.Games
            .Include(g => g.Genre)
            .Include(g => g.Developer)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
            return NotFound("Game not found.");

        return Ok(game.ToGameDto());
    }


    //* Post: api
    [HttpPost]
    public async Task<ActionResult> CreateGame([FromBody] CreateGameDto gameDto)
    {
        var genre = await _context.Genres.FindAsync(gameDto.GenreId);
        var developer = await _context.Developers.FindAsync(gameDto.DeveloperId);

        if (genre == null || developer == null)
        {
            return BadRequest("Invalid Genre or Developer ID.");
        }

        var newGame = new Models.Game
        {
            Title = gameDto.Title,
            ImageUrl = gameDto.ImageUrl,
            Description = gameDto.Description,
            Genre = genre,
            Developer = developer,
            ReleaseDate = gameDto.ReleaseDate
        };

        _context.Games.Add(newGame);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGameById), new { id = newGame.Id }, newGame.ToGameDto());
        
    }

    //* Update: api/games/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateGame([FromRoute] int id, [FromBody] GameUpdateDto gameDto)
    {
        var game = await _context.Games
        .Include(g => g.Genre)
        .Include(g => g.Developer)
        .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null)
        {
            return NotFound("Game not found.");
        }

        var genre = await _context.Genres.FindAsync(gameDto.GenreId);
        var developer = await _context.Developers.FindAsync(gameDto.DeveloperId);

        if (genre == null || developer == null)
        {
            return BadRequest("Invalid Genre or Developer ID.");
        }

        game.Title = gameDto.Title;
        game.ImageUrl = gameDto.ImageUrl;   
        game.Description = gameDto.Description;
        game.Genre = genre;
        game.Developer = developer;
        game.ReleaseDate = gameDto.ReleaseDate;

        await _context.SaveChangesAsync();
        return NoContent();


    }



    //* Delete: api/games/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteGame([FromRoute] int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);

        if(game == null)
        {
            return NotFound("Game not found.");
        }
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    




    

    


}
