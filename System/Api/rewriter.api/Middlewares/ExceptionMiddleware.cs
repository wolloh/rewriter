﻿
using rewriter.Shared.Common.Responses;
using System.Text.Json;
using rewriter.Shared.Common.Extensions;

namespace rewriter.api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ErrorResponse response = null;
            try
            {
                await next.Invoke(context);
            }
            //catch (ValidationException e)
            //{
            //    //response = e?.Errors.ToErrorResponse();
            //}
            //catch (ProcessException e)
            //{
            //    response = e.ToErrorResponse();
            //}
            catch (Exception e)
            {
                response = e.ToErrorResponse();
            }
            finally
            {
                if (!(response is null))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    await context.Response.StartAsync();
                    await context.Response.CompleteAsync();
                }
            }
        }
    }
}
