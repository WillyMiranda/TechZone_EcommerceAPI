using System.Text.Json;
using TechZone.Ecommerce.Transversal;
using TechZone.Ecommerce.UseCases.Common.Exceptions;

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
            catch (ValidationExceptionCustom ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var response = new Response<Object>();
                response.Message = ResponseMessage.VALIDATION_ERROR;
                response.Errors.AddRange(ex.Errors);

                //await Task.FromResult(JsonConvert.SerializeObject(response));
                await System.Text.Json.JsonSerializer.SerializeAsync(context.Response.Body, response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
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
