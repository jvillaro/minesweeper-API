using Microsoft.EntityFrameworkCore;
using Minesweeper.Shared.Models;

namespace Minesweeper.API.Models
{
    /// <summary>
    /// Minesweeper dbcontext
    /// </summary>
    public class MinesweeperContext : DbContext
    {
        /// <summary>
        /// Game collection
        /// </summary>
        public DbSet<Game> Games { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public MinesweeperContext(DbContextOptions options) : base(options)
        {

        }
    }
}
