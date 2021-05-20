using Saz_TicTacToe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saz_TicTacToe.Services
{
  public class GameService : IGameService
  {
    private readonly IPlayerOptions _playerOptions;

    public GameService(IPlayerOptions playerOptions)
    {
      _playerOptions = playerOptions;
    }

    public int GetPlayersNextPlayingPosition(IEnumerable<string> gameBoard, string nextPlayer)
    {
      throw new NotImplementedException();
    }

    public string GetWinningPlayer(IEnumerable<string> gameBoard)
    {
      throw new NotImplementedException();
    }

    public List<int> GetWinningPosition(IEnumerable<string> gameBoard)
    {
      throw new NotImplementedException();
    }

    public string NextPlayerToPlay(IEnumerable<string> gameBoard)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<string> PlayNextMove(IEnumerable<string> gameBoard, int nextPlayerPostion, string nextPlayer)
    {
      throw new NotImplementedException();
    }

    public void ValidateCurrent(IEnumerable<string> gameBoard)
    {
      if (gameBoard.Count() != 9)
      {
        throw new ArgumentException("Game board must consist of 9 playable postions as elements.");
      }

      if (!gameBoard.All(space => _playerOptions.Symbols.Contains(space)))
      {
        throw new ArgumentException("All playable postions of the game board must be one of \"X\", \"O\", or \"?\".");
      }

      var playerDiffernece = gameBoard.Count(p => p == _playerOptions.X) - gameBoard.Count(p => p == _playerOptions.O);

      if (playerDiffernece > 1)
      {
        throw new ArgumentException($"Play cannot be made. {(playerDiffernece > 0 ? "X" : "O")} has {playerDiffernece} more plays than {(playerDiffernece < 0 ? "X" : "O")}.");
      }
    }
  }
}
