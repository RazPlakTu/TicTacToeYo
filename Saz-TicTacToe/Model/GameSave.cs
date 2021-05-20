using System.Collections.Generic;

namespace Saz_TicTacToe.Model
{
  /// <summary>
  ///  This consists of the details representing the game save state
  /// </summary>
  public class GameSave
  {
    /// <summary>
    /// Game board id.
    /// </summary>
    public string GameId { get; set; }

    /// <summary>
    /// The player who won the game, "X"|"O"|"undetermined"|"tie".
    /// </summary>
    public string Winner { get; set; }

    /// <summary>
    /// Array of positions on the game board used by winner to win.
    /// </summary>
    public IEnumerable<int> WinPositions { get; set; }

    /// <summary>
    /// The game board.
    /// </summary>
    public IEnumerable<string> GameBoard { get; set; }

    /// <summary>
    /// Constructs a GameStateUpdate object.
    /// </summary>
    /// <param name="move">The move just played, if applicable.</param>
    /// <param name="playerSymbol">The symbol inferred to belong to the API.</param>
    /// <param name="winner">The win-state of the game.</param>
    /// <param name="winPositions">The positions of the winning scenario, if applicable.</param>
    /// <param name="gameBoard">The new state of the board.</param>
    public GameSave(string gameId, string winner, IEnumerable<int> winPositions, IEnumerable<string> gameBoard)
    {
      GameId = gameId;
      Winner = winner;
      WinPositions = winPositions;
      GameBoard = gameBoard;
    }
  }
}
