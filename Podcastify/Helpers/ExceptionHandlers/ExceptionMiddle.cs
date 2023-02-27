using Microsoft.AspNetCore.Http;
using Podcastify.API.Helpers.ExceptionHandlers.Exceptions;
using System;
using System.Net;
using System.Text.Json;

namespace Podcastify.API.Helpers.ExceptionHandlers
{
    public class ExceptionMiddle
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddle> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddle(
            RequestDelegate next,
            ILogger<ExceptionMiddle> logger,
            IHostEnvironment hostEnvironment)
        {
            _next = next;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ApplicationException ex)
            {
                ConfigureException(ex, httpContext);
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var response = new BaseException(ex.Message);

                await httpContext.Response.WriteAsync(response.ToString());
            }
            catch (Exception ex)
            {
                ConfigureException(ex, httpContext);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _hostEnvironment.IsDevelopment() ?
                    new BaseException(ex.Message, ex.StackTrace.ToString())
                    : new BaseException(ex.Message);

                await httpContext.Response.WriteAsync(response.ToString());
            }
        }

        public void ConfigureException(Exception exception, HttpContext httpContext)
        {
            _logger.LogError(exception, exception.Message);
            httpContext.Response.ContentType = "application/json";
        }
    }
}
