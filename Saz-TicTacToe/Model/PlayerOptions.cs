using Saz_TicTacToe.Interfaces;
using System.Collections.Generic;

namespace Saz_TicTacToe.Model
{
  public class PlayerOptions : IPlayerOptions
  {
    public string X { get; set; }
    public string O { get; set; }
    public string Empty { get; set; }
    public string Undertermined { get; set; }
    public string Tie { get; set; }
    public string[] Players { get; set; }
    public string[] Symbols { get; set; }
    public List<List<int>> WinningPositions { get; set; }

    public PlayerOptions()
    {
      X = "X";
      O = "O";
      Empty = "?";
      Undertermined = "undertermined";
      Tie = "tie";
      Players = new string[] { X, O };
      Symbols = new string[] { X, O, Empty };
      WinningPositions = new List<List<int>>
      {
          // Horizontal Positions
          new List<int> { 0, 1, 2 },
          new List<int> { 3, 4, 5 },
          new List<int> { 6, 7, 8 },
          // Vertical Positions
          new List<int> { 0, 3, 6 },
          new List<int> { 1, 4, 7 },
          new List<int> { 2, 5, 8 },
          // Diagonal Positions
          new List<int> { 0, 4, 8 },
          new List<int> { 2, 4, 6 },
      };
    }
  }
}
