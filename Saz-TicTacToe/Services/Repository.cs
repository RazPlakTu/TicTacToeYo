using Newtonsoft.Json;
using Saz_TicTacToe.Interfaces;
using Saz_TicTacToe.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Saz_TicTacToe.Services
{
  public class Repository : IRepository
  {
    private readonly IRepositoryState _repositoryState;
    private readonly IFileProvider _fileProvider;

    public Repository(IRepositoryState repositoryState, IFileProvider fileProvider)
    {
      _repositoryState = repositoryState;
      _fileProvider = fileProvider;
    }

    public async Task HydrateRepositoryStateAsync()
    {
      foreach (var filePath in _fileProvider.GetFileContents("GameSaves"))
      {
        _repositoryState.GameSaves.Add(DeserilizeFromJsonString<GameSave>(await _fileProvider.ReadFileAsync(filePath)));
      }
    }

    public async Task OutputGameSaveAsync(GameSave gameSave)
    {
      var path = Path.Combine("GameSaves", $"{Guid.NewGuid().ToString()}.json");
      var data = JsonConvert.SerializeObject(gameSave, Formatting.None);

      await _fileProvider.WriteFileAsync(data, path);
    }

    public async Task<List<GameSave>> GetAllGameSaveAsync()
    {
      var results = new List<GameSave>();
      foreach (var filePath in _fileProvider.GetFileContents("GameSaves"))
      {
        results.Add(DeserilizeFromJsonString<GameSave>(await _fileProvider.ReadFileAsync(filePath)));
      }

      return results;
    }

    private T DeserilizeFromJsonString<T>(string content)
    {
      return JsonConvert.DeserializeObject<T>(content);
    }
  }
}
