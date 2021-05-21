using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Saz_TicTacToe.Model;
using System;
using System.Net;

namespace Saz_TicTacToe.ExceptionHandler
{
  /// <summary>
  /// Catches and handles all transient error exceptions thrown triggered from processing requests.
  /// </summary>
  /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter" />
  public class GameServiceExceptionHandler : IExceptionFilter
  {
    /// <summary>
    /// Called after an action has thrown an <see cref="T:System.Exception" />.
    /// </summary>
    /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
    public void OnException(ExceptionContext context)
    {
      HttpResponse httpResponse = context.HttpContext.Response;
      httpResponse.ContentType = "application/json";

      ErrorResponse errorResponse;

      if (context.Exception is ArgumentException)
      {
        httpResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        errorResponse = new ErrorResponse(1, context.Exception.Message);
      }
      else
      {
        httpResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        errorResponse = new ErrorResponse(0, $"An internal error has occured: {context.Exception.Message}");
      }

      string jsonResult = JsonConvert.SerializeObject(errorResponse, Formatting.Indented);

      context.ExceptionHandled = true;

      httpResponse.WriteAsync(jsonResult).ConfigureAwait(false);
    }
  }
}
