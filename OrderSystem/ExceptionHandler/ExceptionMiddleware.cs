using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using OrderSystem.ExceptionHandler;
using OrderSystem.Global;
using OrderSystem.Models;
using OrderSystem.Repository.Interface;
using System.Net;
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IExceptionRepository _exceptionRepository;

    public ExceptionHandlerMiddleware(RequestDelegate next,IExceptionRepository exceptionRepository)
    {
        _next = next;
        _exceptionRepository = exceptionRepository;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            LogException(context, ex);
            await HandleExceptionAsync(context, ex);
        }
    }
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpStatusCode statusCode = (HttpStatusCode)GetStatusCodeFromException(exception);
        var response = new ApiResponse(false, statusCode, null, exception.Message);
        var responseJson = JsonConvert.SerializeObject(response);
        return context.Response.WriteAsync(responseJson);
    }
    private void LogException(HttpContext context, Exception exception)
    {
        string exceptionMessage = exception.Message;
        string methodName = context.Request.Method;
        int userId = GlobalVariables.UserId;

        var error = new ExceptionAddParaModel()
        {
            MethodName = methodName,
            Message = exceptionMessage,
            UserId = userId
        };
        if (methodName != null)
        {
            _exceptionRepository.AddErrorAsync(error);
        }
    }
    private static int GetStatusCodeFromException(Exception exception)
    {
        if (exception is BadRequest)
        {
            return (int)HttpStatusCode.BadRequest;
        }
        else if (exception is UnauthorizedAccessException)
        {
            return (int)HttpStatusCode.Unauthorized;
        }
        else if (exception is NotFound)
        {
            return (int)HttpStatusCode.NotFound;
        }
        else if (exception is Conflict)
        {
            return (int)HttpStatusCode.Conflict;
        }
        else
        {
            return (int)HttpStatusCode.InternalServerError;
        }
    }

}