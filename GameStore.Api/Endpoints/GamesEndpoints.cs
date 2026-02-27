using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{   
    // Define a constant for the endpoint name to avoid hardcoding it in multiple places and to prevent typos
    const string GetGameEndpointName = "GetGame";

    public static void MapGamesEndpoints(this WebApplication app)
    {
        // optionaly, add a group for better organization (app.MapGroup("/games")) and move all endpoints inside that group. This will automatically prefix all routes with /games
        var gamesGroup = app.MapGroup("/games");

        // GET /games - returns a list of games
        gamesGroup.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Games.Include(game => game.Genre).Select(
            game => new GameSummaryDTO(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            )
        ).AsNoTracking().ToListAsync());

        // GET /games/{id} - returns a single game by ID
        gamesGroup.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            var game = await dbContext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(
                new GameDetailsDTO(
                    game.Id,
                    game.Name,
                    game.GenreId,
                    game.Price,
                    game.ReleaseDate
                )
            );
        }).WithName(GetGameEndpointName);

        // POST /games - adds a new game to the list
        gamesGroup.MapPost("/", async (CreateGameDTOs newGame, GameStoreContext dbContext) =>
        {
            Game game = new()
            {
                Name = newGame.Name,
                GenreId = newGame.GenreId,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            GameDetailsDTO gameDto = new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameDto.Id }, gameDto);
        });

        // PUT /games/{id} - updates an existing game
        gamesGroup.MapPut("/{id}", async (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            existingGame.Name = updatedGame.Name;
            existingGame.GenreId = updatedGame.GenreId;
            existingGame.Price = updatedGame.Price;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;

            // No need to call dbContext.Games.Update(existingGame) because the entity is already being tracked by the context, so any changes made to it will be automatically detected and saved when SaveChangesAsync is called.
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /games/{id} - deletes a game by ID
        gamesGroup.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            // Instead of first fetching the game and then deleting it, we can directly execute a delete command on the database for the game with the specified ID. This is more efficient as it avoids the overhead of fetching the entity into memory.
            await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();
        });
    }
}
