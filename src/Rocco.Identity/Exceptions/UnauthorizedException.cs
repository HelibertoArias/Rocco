using System;

namespace Rocco.Identity.Exceptions;


public class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string message) : base(message)
    {

    }
}