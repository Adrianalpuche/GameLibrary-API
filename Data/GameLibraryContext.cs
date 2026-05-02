using System;
using GameLibrary.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Data;

public class GameLibraryContext(DbContextOptions<GameLibraryContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();
    public DbSet<Developer> Developers => Set<Developer>();
    public DbSet<Genre> Genres => Set<Genre>();

}
