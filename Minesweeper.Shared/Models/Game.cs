using Minesweeper.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Guid GameId { get; private set; }

        /// <summary>
        /// Player's email for saving the game
        /// </summary>
        public string PlayerEmail { get; set; }

        /// <summary>
        /// Name given to the game on save (Optional)
        /// </summary>
        public string GameName { get; set; }

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
        /// Game state
        /// </summary>
        public GameState State { get; set; }

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


        #region --- Constructor ---

        /// <summary>
        /// Constructor
        /// </summary>
        public Game(int rows, int columns, int numberOfMines)
        {
            GameId = Guid.NewGuid();
            PlayerEmail = string.Empty;
            GameName = string.Empty;
            Created = DateTime.Now;
            Started = DateTime.Now;
            Ended = DateTime.Now;
            Rows = rows;
            Columns = columns;
            NumberOfMines = numberOfMines;
            State = GameState.Created;
            Board = InitializeBoard(rows, columns, numberOfMines);
            CalculateAdjacentMines();
        }

        #endregion --- Constructors ---


        #region --- InitializeBoard ---

        /// <summary>
        /// Initialize the game board
        /// </summary>
        public BoardCell[,] InitializeBoard(int rows, int columns, int numberOfMines)
        {
            var board = new BoardCell[rows, columns];

            // Create a list of positions of all cells
            List<Tuple<int, int>> cellList = new List<Tuple<int, int>>();
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    cellList.Add(new Tuple<int, int>(row, column));

                    // Initialize cells
                    board[row, column] = new BoardCell()
                    {
                        Row = row + 1,
                        Column = column + 1,
                        AdjacentMines = 0,
                        HasMine = false,
                        State = CellState.Hidden
                    };
                }
            }

            // Get random positions for mines
            var random = new Random(DateTime.Now.Millisecond);
            var mines = cellList.OrderBy(x => random.Next()).Take(numberOfMines);

            // Update the cells that have mines
            foreach (var mine in mines)
            {
                board[mine.Item1, mine.Item2].HasMine = true;
            }

            return board;
        }

        #endregion --- InitializeBoard ---


        #region --- CalculateAdjacentMines ---

        /// <summary>
        /// Calculates each cells adjacent mines
        /// </summary>
        public void CalculateAdjacentMines()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    var adjacentMines = 0;

                    if (HasMine(row - 1, column - 1)) adjacentMines++;  // NW
                    if (HasMine(row - 1, column)) adjacentMines++;      // N
                    if (HasMine(row - 1, column + 1)) adjacentMines++;  // NE
                    if (HasMine(row, column + 1)) adjacentMines++;      // E
                    if (HasMine(row + 1, column + 1)) adjacentMines++;  // SE
                    if (HasMine(row + 1, column)) adjacentMines++;      // S
                    if (HasMine(row + 1, column - 1)) adjacentMines++;  // SW
                    if (HasMine(row, column - 1)) adjacentMines++;      // W

                    Board[row, column].AdjacentMines = adjacentMines;
                }
            }
        }

        #endregion --- CalculateAdjacentMines ---


        #region --- ValidCellPosition ---

        /// <summary>
        /// Checks if the cell position is valid
        /// </summary>
        /// <param name="row">Cell row</param>
        /// <param name="column">Cell column</param>
        /// <returns></returns>
        public bool ValidCellPosition(int row, int column)
        {
            return (row >= 0) && (row < Rows) &&
                   (column >= 0) && (column < Columns);
        }

        #endregion --- ValidPosition ---


        #region --- HasMine ---

        /// <summary>
        /// Check if the cell has a mine
        /// </summary>
        /// <param name="row">Cell row</param>
        /// <param name="column">Cell column</param>
        /// <returns>True if there is a mine, false if not</returns>
        public bool HasMine(int row, int column)
        {
            if (!ValidCellPosition(row, column)) return false;
            return Board[row, column].HasMine ? true : false;
        }

        #endregion --- HasMine ---
    }
}
