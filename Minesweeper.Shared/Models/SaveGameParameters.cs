using System;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Parameters for saving a game
    /// </summary>
    public class SaveGameParameters
    {
        /// <summary>
        /// Game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Players email
        /// </summary>
        public string PlayerEmail { get; set; }

        /// <summary>
        /// Game name
        /// </summary>
        public string GameName { get; set; }
    }
}
