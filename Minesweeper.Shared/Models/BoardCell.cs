using System;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Class that represents a minesweeper board cell
    /// </summary>
    public class BoardCell
    {
        /// <summary>
        /// X coordinate of the cell on the board
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y coordinate of the cell on the board
        /// </summary>
        public int Y { get; set; }

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
