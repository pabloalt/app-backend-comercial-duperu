using Scharff.Domain.Response;
using Scharff.Domain.Util.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace Scharff.API.Util.GlobalHandler
{
    public class GlobalErrorHandler
    {
        private readonly ILogger<GlobalErrorHandler> _logger;
        private readonly RequestDelegate _next;

        public GlobalErrorHandler(RequestDelegate next, ILogger<GlobalErrorHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try 
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError(error, error.Message, null);
                var response = context.Response;
                response.ContentType = "application/json";
                CustomResponse<string> errorResponse = new();

                switch (error) 
                {
                    case NotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        errorResponse.error?.Add(error.Message);
                        errorResponse.message = error.Message;
                        break;

                    case BadRequestException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.error?.Add(error.Message);
                        errorResponse.message = error.Message;
                        break;

                    case ValidationException:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.error?.Add(error.Message);
                        errorResponse.message = error.Message;
                        break;

                    case FluentValidation.ValidationException e:
                        List<string> errorsModel = new();
                        e.Errors.ToList().ForEach(error => errorsModel.Add(error.ErrorMessage));
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errorResponse.error = errorsModel;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        errorResponse.error?.Add("Ocurrio un error en el sistema");
                        break;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var result = JsonSerializer.Serialize(errorResponse, options);
                await response.WriteAsync(result);
            }
        }
    }
}
