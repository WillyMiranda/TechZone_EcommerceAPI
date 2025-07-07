using System.Text.Json;
using TechZone.Ecommerce.Transversal;

namespace TechZone.Ecommerce.WebApi.Modules.GlobalException
{
    public class GlobalExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var response = new Response<Object>();
                response.Message = ResponseMessage.INTERNAL_ERROR;
                response.Errors.Add(new BaseError { ErrorMessage = ex.Message });

                await System.Text.Json.JsonSerializer.SerializeAsync(context.Response.Body, response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            }
        }
    }
}
