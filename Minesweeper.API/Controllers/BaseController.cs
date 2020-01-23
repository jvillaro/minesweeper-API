using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Minesweeper.API.Models;
using System;
using System.Threading.Tasks;

namespace Minesweeper.API.Controllers
{
    /// <summary>
    /// Base for controllers
    /// </summary>
    public class BaseController : ControllerBase
    {
        protected readonly MinesweeperContext db;
        private readonly ILogger<GamesController> logger;

        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController(ILogger<GamesController> logger, MinesweeperContext db)
        {
            this.db = db;
            this.logger = logger;
        }

        #endregion --- Constructor ---


        #region --- InternalServerError ---

        /// <summary>
        /// Returns the Internal server error status code
        /// </summary>
        protected ObjectResult InternalServerError(string message = "")
        {
            var result = new ObjectResult(message);
            result.StatusCode = StatusCodes.Status500InternalServerError;

            return result;
        }

        #endregion --- InternalServerError ---


        #region --- ExecuteAsync ---

        /// <summary>
        /// Executes a method
        /// </summary>      
        protected async Task<IActionResult> ExecuteAsync(Func<Task<object>> method)
        {
            try
            {
                var result = await method();

                if (result is IActionResult httpResult)
                {
                    return httpResult;
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return InternalServerError();
        }

        /// <summary>
        /// Executes a method without return type
        /// </summary>      
        protected async Task<IActionResult> ExecuteAsync(Func<Task> method)
        {
            try
            {
                await method();

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

            return InternalServerError();
        }

        #endregion --- ExecuteAsync ---
    }
}
