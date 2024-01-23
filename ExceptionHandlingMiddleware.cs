
using DotNetCore8Api.Exceptions;

namespace DotNetCore8Api
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (DomainNotFoundException ex)
            {
                context.Response.StatusCode = (int)StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (DomainValidationException ex)
            {
                context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(e.Message);
            }
        }
    }
}
