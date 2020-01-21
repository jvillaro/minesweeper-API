using System;
using System.Threading.Tasks;

namespace Minesweeper.Shared.Models
{
    /// <summary>
    /// Represents a minesweeper game 
    /// </summary>
    public class Game
    {
        #region --- Properties ---

        /// <summary>
        /// Game Id
        /// </summary>
        public Guid GameId { get; set; }

        /// <summary>
        /// Player's email for saving the game
        /// </summary>
        public string PlayerEmail { get; set; }

        /// <summary>
        /// Name given to the game on save (Optional)
        /// </summary>
        public string MyProperty { get; set; }

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

        /// <summary>
        /// Matrix of board cells
        /// </summary>
        public BoardCell[,] Board { get; set; }

        /// <summary>
        /// When the game was created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// When the game started (first cell interaction)
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// When the game ended
        /// </summary>
        public DateTime Ended { get; set; }

        /// <summary>
        /// Time that has elapsed during game play
        /// </summary>
        public TimeSpan Duration { get; set; }

        #endregion --- Properties ---


        #region --- Constructors ---

        /// <summary>
        /// Constructor
        /// </summary>
        private Game()
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        public Game(int height, int width, int numberOfMines)
        {
            Height = height;
            Width = width;
            NumberOfMines = numberOfMines;
            Board = new BoardCell[height, width];
        }

        #endregion --- Constructors ---
    }
}
