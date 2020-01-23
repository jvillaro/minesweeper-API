using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minesweeper.API.Models;
using Minesweeper.Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Minesweeper.API.Controllers
{
    /// <summary>
    /// Controller for game related actions
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GamesController : BaseController
    {
        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbContext"></param>
        public GamesController(ILogger<GamesController> logger, MinesweeperContext dbContext)
            : base(logger, dbContext)
        {

        }

        #endregion --- Constructor ---


        #region --- NewGameAsync ---

        /// <summary>
        /// Create a new game
        /// </summary>
        /// <param name="parameters">Initial parameters</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> NewGameAsync([FromBody] NewGameParameters parameters)
        {
            return await ExecuteAsync(async () =>
            {
                var game = new Game(parameters.Rows, parameters.Columns, parameters.NumberOfMines);

                //db.Games.Add(game);
                //await db.SaveChangesAsync();

                return game;
            });
        }

        #endregion --- NewGameAsync ---


        #region --- SaveGameAsync ---

        /// <summary>
        /// Save the game
        /// </summary>
        /// <param name="parameters">Save game parameters</param>
        /// <returns></returns>
        [HttpPost("Save")]
        public async Task<IActionResult> SaveGameAsync([FromBody] SaveGameParameters parameters)
        {
            return await ExecuteAsync(async () =>
            {

            });
        }

        #endregion --- SaveGameAsync ---


        #region --- GetGamesAsync ---

        /// <summary>
        /// Gets all the games
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGamesAsync()
        {
            return await ExecuteAsync(async () =>
            {
                //var games = db.Games.ToList();
                //return games;
            });
        }

        #endregion --- GetGamesAsync ---


        #region --- GetGamesByPlayerEmailAsync ---

        /// <summary>
        /// Gets all the users games by his or her email
        /// </summary>
        /// <param name="playerEmail">Players email</param>
        /// <returns></returns>
        [HttpGet("{playerEmail}")]
        public async Task<IActionResult> GetGamesByPlayerEmailAsync(string playerEmail)
        {
            return await ExecuteAsync(async () =>
            {
                var games = db.Games.Where(x => x.PlayerEmail == playerEmail).ToList();
                return games;
            });
        }

        #endregion --- GetGamesByPlayerEmailAsync ---


        #region --- LoadGameAsync ---

        /// <summary>
        /// Loads the specified game
        /// </summary>
        /// <param name="gameId">Game ID</param>
        /// <returns></returns>
        [HttpGet("Load/{gameId}")]
        public async Task<IActionResult> LoadGameAsync(Guid gameId)
        {
            return await ExecuteAsync(async () =>
            {
                //var game = db.Games.FirstOrDefault(x => x.GameId == gameId);
                //return game;
            });
        }

        #endregion --- LoadGameAsync ---


        #region --- PlayCellAsync ---

        /// <summary>
        /// Make a play on a cell
        /// </summary>
        /// <param name="parameters">Parameters for making a play</param>
        /// <returns></returns>
        [HttpPost("PlayCell")]
        public async Task<IActionResult> PlayCellAsync([FromBody] PlayCellParameters parameters)
        {
            return await ExecuteAsync(async () =>
            {
                var game = parameters.Game;

                // Because it's receiving 1 based
                var row = parameters.Row - 1;
                var column = parameters.Column - 1;

                // Check if its a valid position
                if (!game.ValidCellPosition(row, column))
                {
                    return InternalServerError("Cell position not valid.");
                }

                game.PlayCell(row, column, parameters.PlayType);

                return game;
            });
        }

        #endregion --- PlayCellAsync ---
    }
}
