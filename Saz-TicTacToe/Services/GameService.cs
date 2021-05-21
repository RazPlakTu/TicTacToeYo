using Saz_TicTacToe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Saz_TicTacToe.Services
{
  public class GameService : IGameService
  {
    private readonly IPlayerOptions _playerOptions;

    private readonly List<int> _winDoublethreatPositions = new List<int> { 1, 5, 1000 };
    private static readonly List<int> _loseDoubleThreatPostions = new List<int> { 0, 4, 100 };

    public GameService(IPlayerOptions playerOptions)
    {
      _playerOptions = playerOptions;
    }

    public int GetPlayersNextPlayingPosition(IEnumerable<string> gameBoard, string nextPlayer)
    {
      var player2 = nextPlayer == _playerOptions.X ? _playerOptions.O : _playerOptions.X;

      var gameScoreCard = new List<int>
      {
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
      };

      var allWinnablePosition = _playerOptions.WinningPositions.Where(pos => GetMatchedWinningPosition(gameBoard, pos).All(p => p != player2));

      foreach (List<int> winnablePosition in allWinnablePosition)
      {
        var matchedWinPosition = GetMatchedWinningPosition(gameBoard, winnablePosition);
        var playerCount = matchedWinPosition.Count(p => p == nextPlayer);
        foreach (var postion in winnablePosition)
        {
          if (((List<string>)gameBoard)[postion] == _playerOptions.Empty)
          {
            gameScoreCard[postion] += _winDoublethreatPositions[playerCount];
          }
        }
      }

      var allLosablePositions = _playerOptions.WinningPositions.Where(pos => GetMatchedWinningPosition(gameBoard, pos).All(p => p != nextPlayer));

      foreach (List<int> losablePosition in allLosablePositions)
      {
        var matchedlosePosition = GetMatchedWinningPosition(gameBoard, losablePosition);
        var playerCount = matchedlosePosition.Count(p => p == player2);
        foreach (var position in losablePosition)
        {
          if (((List<string>)gameBoard)[position] == _playerOptions.Empty)
          {
            gameScoreCard[position] += _loseDoubleThreatPostions[playerCount];
          }
        }
      }

      return Enumerable.Range(0, gameScoreCard.Count())
          .Where(i => gameBoard.ElementAt(i) == _playerOptions.Empty)
          .Aggregate((max, i) => gameScoreCard[max] > gameScoreCard[i] ? max : i);
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

    public IEnumerable<string> PlayNextMove(IEnumerable<string> gameBoard, int nextPlayerPostion, string nextPlayer)
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
