using System.Threading.Tasks;

namespace Saz_TicTacToe.Interfaces
{
  /// <summary>
  /// File system provider. This Provider provides an IO wrapper to read and write files
  /// </summary>
  public interface IFileProvider
  {
    /// <summary>
    /// Reads the contents of a file and returns the string and returns the content.
    /// </summary>
    /// <param name="path">The location of the file.</param>
    /// <returns>The contents of the File as a string.</returns>
    Task<string> ReadFileAsync(string path);
    /// <summary>
    /// Writes the content to a given path.
    /// </summary>
    /// <param name="content">The content to write.</param>
    /// <param name="path">The location of the file to write to.</param>
    /// <returns>Return a task when the write operation has been completed.</returns>
    Task WriteFileAsync(string content, string path);
    /// <summary>
    /// Ensures that the directory from the specified path exists and create it if it does nbt.
    /// </summary>
    /// <param name="path">The path to the directory that should exists.</param>
    void EnsureDirectoryExists(string path);
    /// <summary>
    /// Reads all file content from the specified cirirectory/
    /// </summary>
    /// <param name="path">THe path to the directory that should read from.</param>
    /// <returns>Return all file content from the specied path.</returns>
    string[] GetFileContents(string path);
  }
}
