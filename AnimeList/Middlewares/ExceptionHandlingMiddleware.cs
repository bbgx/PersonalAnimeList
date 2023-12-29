﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace AnimeList.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpRequestException httpEx)
            {
                await HandleExceptionAsync(httpContext, httpEx);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = StatusCodes.Status500InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case HttpRequestException httpEx:
                    code = (int)httpEx.StatusCode;
                    result = JsonSerializer.Serialize(new { message = httpEx.Message });
                    break;
                default:
                    result = JsonSerializer.Serialize(new { message = exception.Message });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
