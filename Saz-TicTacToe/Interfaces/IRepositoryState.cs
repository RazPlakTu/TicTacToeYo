using Saz_TicTacToe.Model;
using System.Collections.Generic;

namespace Saz_TicTacToe.Interfaces
{
  /// <summary>
  /// Serves as memory cache of already read models and stores them locally to prevent reading of files repeatedly
  /// </summary>
  public interface IRepositoryState
  {
    IList<GameSave> GameSaves { get; set; }
  }
}
