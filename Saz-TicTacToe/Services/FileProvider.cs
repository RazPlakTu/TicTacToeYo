using Microsoft.Extensions.Options;
using Saz_TicTacToe.Interfaces;
using Saz_TicTacToe.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Saz_TicTacToe.Services
{
  public class FileProvider : IFileProvider
  {
    private readonly string _basePath;

    public FileProvider(IOptions<ApplicationConfiguration> options)
    {
      _basePath = !string.IsNullOrEmpty(options.Value.BasePath) ? options.Value.BasePath : Path.Combine(
             Directory.GetParent(AppContext.BaseDirectory).FullName,
                "..",
                "..",
                "..",
                "..",
                "..",
                "AppData"
        );
    }
    public void EnsureDirectoryExists(string path)
    {
      var fullPath = Path.Combine(_basePath, path);
      if (!Directory.Exists(fullPath))
      {
        Directory.CreateDirectory(fullPath);
      }
    }

    public string[] GetFileContents(string path)
    {
      var fullPath = Path.Combine(_basePath, path);
      return Directory.GetFiles(fullPath);
    }

    public async Task<string> ReadFileAsync(string path)
    {
      var fullPath = Path.Combine(_basePath, path);
      return await File.ReadAllTextAsync(fullPath);
    }

    public async Task WriteFileAsync(string content, string path)
    {
      var fullPath = Path.Combine(_basePath, path);
      try
      {
        await File.WriteAllTextAsync(fullPath, content);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
