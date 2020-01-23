using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minesweeper.API.Models;
using Minesweeper.Shared.Models;
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

                return game;
            });
        }

        #endregion --- NewGameAsync ---
    }
}
