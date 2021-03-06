using Microsoft.AspNetCore.Mvc;
using Saz_TicTacToe.Interfaces;
using Saz_TicTacToe.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Saz_TicTacToe.Controllers
{
  /// <summary>
  /// This API simulates a game of Tic Tac Toe based on the current state of the game board.
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class TicTacToeController : ControllerBase
  {
    private readonly IPlayerOptions _playerOptions;
    private readonly IGameService _gameService;
    private readonly IRepository _repository;

    public TicTacToeController(IGameService gameService, IPlayerOptions playerOptions, IRepository repository)
    {
      _playerOptions = playerOptions;
      _gameService = gameService;
      _repository = repository;
    }

    /// <summary>
    /// Simulates a game of Tic Tac Toe. 
    /// </summary>
    /// <aram name="">This represents the current state of game board.</aram>
    /// <returns>Representation of the current game prior to a players move .</returns>
    [HttpPost]
    [ProducesResponseType(typeof(GameSave), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public IActionResult Post(IEnumerable<string> gameBoard)
    {
      var gameID = Guid.NewGuid().ToString();
      _gameService.ValidateCurrent(gameBoard);
      var playerWinner = _gameService.GetWinningPlayer(gameBoard);
      var nextPlayer = _gameService.NextPlayerToPlay(gameBoard);

      if (playerWinner == _playerOptions.Undertermined)
      {
        var nextPlayerPostion = _gameService.GetPlayersNextPlayingPosition(gameBoard, nextPlayer);
        var resultingGameBoard = _gameService.PlayNextMove(gameBoard, nextPlayerPostion, nextPlayer);

        return new ObjectResult(new GameSave(
          gameID,
          _gameService.GetWinningPlayer(resultingGameBoard),
          _gameService.GetWinningPosition(resultingGameBoard),
          resultingGameBoard
          ));
      }
      else
      {
        var gameSave = new GameSave(
          gameID,
          _gameService.GetWinningPlayer(gameBoard),
          _gameService.GetWinningPosition(gameBoard),
          gameBoard
          );

        _repository.OutputGameSaveAsync(gameSave);
        return new ObjectResult(gameSave);
      }
    }

    /// <summary>
    /// Get the results of all possibily plasyed games.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<GameSave>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Get()
    {
      var rtx = await _repository.GetAllGameSaveAsync();
      return new ObjectResult(rtx);
    }
  }
}
