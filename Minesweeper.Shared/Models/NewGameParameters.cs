using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// New game parameters
    /// </summary>
    public class NewGameParameters
    {
        /// <summary>
        /// Number of vertical cells
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// Number of horizontal cells
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// Number of mines the board will have
        /// </summary>
        public int NumberOfMines { get; set; }
    }
}
