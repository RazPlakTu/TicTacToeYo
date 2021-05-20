namespace Saz_TicTacToe.Model
{
  /// <summary>
  /// Error resposnse from API based on request
  /// </summary>
  public class ErrorResponse
  {
    /// <summary>
    /// Error message as part of the error response
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Error code from response HTTP Status Code.
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// Error Response Constaructor.
    /// </summary>
    /// <param name="message">Text to send to requestor.</param>
    /// <param name="code">Error code to send to requestor. 1 indicates an improper input, 0 is a catch-all.</param>
    public ErrorResponse(int code, string message)
    {
      Code = code;
      Message = message;
    }
  }
}
