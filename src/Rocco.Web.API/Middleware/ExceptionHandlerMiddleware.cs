// <copyright file="ExceptionHandlerMiddleware.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Net;

using Newtonsoft.Json;
using Rocco.Application.Exceptions;
using Rocco.Identity.Exceptions;

namespace Rocco.Web.API.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await ConvertException(context, ex);
        }
    }

    private static Task ConvertException(HttpContext context, Exception exception)
    {
        var httpStatusCode = HttpStatusCode.InternalServerError;

        context.Response.ContentType = "application/json";

        var result = string.Empty;

        switch (exception)
        {
            case ValidationException validationException:
                httpStatusCode = HttpStatusCode.BadRequest;
                result = JsonConvert.SerializeObject(validationException.ValdationErrors);
                break;
            case BadRequestException badRequestException:
                httpStatusCode = HttpStatusCode.BadRequest;
                //result = badRequestException.Message;
                break;
            case NotFoundException notFoundException:
                httpStatusCode = HttpStatusCode.NotFound;
                break;

            case RegisterUserException registerUserException:
                httpStatusCode = HttpStatusCode.BadRequest;
                break;
            case Exception ex:
                httpStatusCode = HttpStatusCode.BadRequest;
                //result = ex.Message;
                if (ex.InnerException != null)
                {
                    result = JsonConvert.SerializeObject(new { error = exception.InnerException.Message });
                }

                break;

        }

        context.Response.StatusCode = (int)httpStatusCode;

        if (result == string.Empty)
        {
            result = JsonConvert.SerializeObject(new { error = exception.Message });
        }

        return context.Response.WriteAsync(result);
    }
}
