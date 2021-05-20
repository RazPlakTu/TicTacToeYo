using System.Collections.Generic;

namespace Saz_TicTacToe.Interfaces
{
  /// <summary>
  /// The public contract representing model for player options
  /// </summary>
  public interface IPlayerOptions
  {
    /// <summary>
    /// A player symbol representing X that was position within the game board. It will also be use to determine winner.
    /// </summary>
    string X { get; set; }
    /// <summary>
    /// A player symbol representing O that was position within the game board. It will also be use to determine winner.
    /// </summary>
    string O { get; set; }
    /// <summary>
    /// A player symbol representing ? which represent an empty position within the game board.
    /// </summary>
    string Empty { get; set; }
    /// <summary>
    /// Represents an unfinished game.
    /// </summary>
    string Undertermined { get; set; }
    /// <summary>
    /// Represent that the game determined no winners
    /// </summary>
    string Tie { get; set; }
    string[] Players { get; set; }
    string[] Symbols { get; set; }
    /// <summary>
    /// A data structure which will be used to represent indexes with the game board that produces a win.
    /// The position [0, 1, 2] of WinningIndexes means that if a player plays in all of the top 3 positions of the board, they won.
    /// </summary>
    List<List<int>> WinningPositions { get; set; }
  }
}