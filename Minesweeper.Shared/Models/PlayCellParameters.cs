using Minesweeper.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Parameters for making a play
    /// </summary>
    public class PlayCellParameters
    {
        /// <summary>
        /// Game
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Row column (1 based)
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Cell column (1 based)
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// Type of play
        /// </summary>
        public PlayType PlayType { get; set; }
    }
}
