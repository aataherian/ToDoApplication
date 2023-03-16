

namespace ToDoApplication.Presentation.Middlewares;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly Serilog.ILogger _logger;
    public GlobalExceptionHandler(RequestDelegate next)
    {
        this._next = next;
        this._logger = Serilog.Log.Logger;

    }





    public async Task InvokeSync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch(Exception exception)
        {
            

            var errorReport = new {
                                    method = context.Request.Method ?? "Unknown Method",
                                    path = context.Request.Path.Value ?? "Unkonwn Path",
                                    endPoint = context.GetEndpoint()?.DisplayName ?? "Unknwon EndPoint",
                                    message = exception.Message,
                                    source = exception.Source,
                                    stackTrace = exception.StackTrace
            };

            _logger.Error("Error: {0}", errorReport);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync("Unfortunately, Something went Wrong on the server.");
        }
    }
    
}