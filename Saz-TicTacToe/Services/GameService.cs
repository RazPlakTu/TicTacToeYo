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
      var winningPosition = GetWinningPosition(gameBoard);
      if (winningPosition != null)
      {
        return GetMatchedWinningPosition(gameBoard, winningPosition).First();
      }

      return gameBoard
          .All(s => s != _playerOptions.Empty) ?
          _playerOptions.Tie :
          _playerOptions.Undertermined;
    }

    public List<int> GetWinningPosition(IEnumerable<string> gameBoard)
    {
      foreach(var winningPosition in _playerOptions.WinningPositions)
      {
        var matchedWinningPositions = GetMatchedWinningPosition(gameBoard, winningPosition);
        var firstPostion = matchedWinningPositions.First();

        if (firstPostion != _playerOptions.Empty)
        {
          var isWinner = matchedWinningPositions.Skip(1).All(mp => mp == firstPostion);
          if (isWinner)
          {
            return winningPosition;
          }
        }
      }
      return null;
    }

    public string NextPlayerToPlay(IEnumerable<string> gameBoard)
    {
      return gameBoard.Count(p => p == _playerOptions.O) >=
        gameBoard.Count(p => p == _playerOptions.X) ?
        _playerOptions.X :
        _playerOptions.O;
    }

    public IEnumerable<string> NextPlayerToMove(IEnumerable<string> gameBoard, int nextPlayerPostion, string nextPlayer)
    {
      return gameBoard.Select((p, i) => i == nextPlayerPostion ? nextPlayer : p);
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

    private IEnumerable<string> GetMatchedWinningPosition(IEnumerable<string> gameBoard, IEnumerable<int> winningPosition)
    {
      return winningPosition.Select(p => gameBoard.ElementAt(p));
    }
  }
}
