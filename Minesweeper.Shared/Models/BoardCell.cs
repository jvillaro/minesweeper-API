using Minesweeper.Shared.Enums;
using System;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Class that represents a minesweeper board cell
    /// </summary>
    public class BoardCell
    {
        /// <summary>
        /// Row of the cell on the board
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Column of the cell on the board
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Indicates if the cell has a mine
        /// </summary>
        public bool HasMine { get; set; }

        /// <summary>
        /// Amount of bombs in the adjacent cells
        /// </summary>
        public int AdjacentMines { get; set; }

        /// <summary>
        /// Cell state
        /// </summary>
        public CellState State { get; set; }
    }
}
