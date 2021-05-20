using Saz_TicTacToe.Interfaces;
using System.Collections.Generic;

namespace Saz_TicTacToe.Model
{
  public class RepositoryState : IRepositoryState
  {
    public IList<GameSave> GameSaves { get; set; }

    public RepositoryState()
    {
      GameSaves = new List<GameSave>();
    }
  }
}
