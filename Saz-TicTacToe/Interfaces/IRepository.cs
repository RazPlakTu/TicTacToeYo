using Saz_TicTacToe.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saz_TicTacToe.Interfaces
{
  /// <summary>
  /// Data access layer for retrieving and writing of the game save data.
  /// </summary>
  public interface IRepository
  {
    /// <summary>
    /// Loads content from the filesystem into the state.
    /// </summary>
    /// <returns></returns>
    Task HydrateRepositoryStateAsync();
    /// <summary>
    /// Writes out the result from the game as a game save.
    /// </summary>
    /// <param name="gameSave">The result from the game.</param>
    /// <returns></returns>
    Task OutputGameSaveAsync(GameSave gameSave);
    /// <summary>
    /// Retrieves all game saves.
    /// </summary>
    /// <returns></returns>
    Task<List<GameSave>> GetAllGameSaveAsync();
  }
}
