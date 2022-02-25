// <copyright file="BaseResponse.cs" company="Rocco Company">
// Copyright (c) 2022, Heliberto Arias
// </copyright>

using System.Collections.Generic;

namespace Rocco.Application.Responses;

public abstract class BaseResponse
{
    public bool Success { get; set; }

    public string Message { get; set; } = null!;

    public List<string> ValidationErrors { get; set; } = null!;

    public BaseResponse()
    {
        Success = true;
    }

    public BaseResponse(string message = null!)
    {
        Success = true;
        Message = message;
    }

    public BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

}
