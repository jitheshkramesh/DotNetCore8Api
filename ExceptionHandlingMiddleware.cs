
using DotNetCore8Api.Exceptions;

namespace DotNetCore8Api
{
    public class ExceptionHandlingMiddleware :IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context,RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainNotFoundException ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.StatusCode = (int)StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (DomainValidationException ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
        }
    }
}
