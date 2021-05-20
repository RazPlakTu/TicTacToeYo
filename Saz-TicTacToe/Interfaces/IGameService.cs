using System.Collections.Generic;

namespace Saz_TicTacToe.Interfaces
{
  public interface IGameService
  {
    /// <summary>
    /// Validates the current game board to determine if it's valid.
    /// </summary>
    /// <param name="gameBoard">Valid boards have 9 symbols, all either "X"|"O"|"?" 
    /// and the difference between "X" and "O" is no more than 1 play.</param>
    /// <returns>
    /// Return whether the current game board is valid.
    /// </returns>
    void ValidateCurrent(IEnumerable<string> gameBoard);
    /// <summary>
    /// Determines which player won the game based on the game board.
    /// </summary>
    /// <returns>One of "X"|"O"|"tie"|"undertermined".</returns>
    string GetWinningPlayer(IEnumerable<string> gameBoard);
    /// /// <summary>
    /// Used to determine the winning index based on the current game board for a given player.
    /// </summary>
    /// <returns>A list of indices based on the game board, indicating a win. If no player has won, returns null.</returns>
    List<int> GetWinningPosition(IEnumerable<string> gameBoard);
    /// <summary>
    /// Used to determine which players next based on the current game board.
    /// </summary>
    /// <returns>The player determined to play next.</returns>
    /// <remarks>
    /// Dafault "X" in cases where it cannot decide.
    /// </remarks>
    string NextPlayerToPlay(IEnumerable<string> gameBoard);
    /// <summary>
    /// This method determines the players next postion based on the current game bord is the resulting winner was undertermined.
    /// </summary>
    /// <param name="gameBoard">Represents the current state of a game board.</param>
    /// <param name="nextPlayer">Represent the the player.</param>
    /// <returns>The players postion used to play next move.</returns>
    int GetPlayersNextPlayingPosition(IEnumerable<string> gameBoard, string nextPlayer);
    /// <summary>
    /// Used to play the next moved on the game baord.
    /// </summary>
    /// <param name="gameBoard">the  current game baord for next moved to be played on.</param>
    /// <param name="nextPlayerPostion">Represents the players position on the game board.</param>
    /// <param name="nextPlayer">Represents which players turn is it.</param>
    /// <returns></returns>
    IEnumerable<string> NextPlayerToMove(IEnumerable<string> gameBoard, int nextPlayerPostion, string nextPlayer);
  }
}
