using System;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Class that represents a minesweeper board cell
    /// </summary>
    public class BoardCell
    {
        /// <summary>
        /// Indicates if the cell has a mine
        /// </summary>
        public bool HasMine { get; set; }

        /// <summary>
        /// Amount of bombs in the adjacent cells
        /// </summary>
        public int NearByMines { get; set; }

        /// <summary>
        /// Indicates if the cell has been flagged by the player
        /// </summary>
        public bool Flagged { get; set; }
    }
}
