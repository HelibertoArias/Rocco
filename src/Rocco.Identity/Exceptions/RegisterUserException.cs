using System;

namespace Rocco.Identity.Exceptions;


public class RegisterUserException : ApplicationException
{
    public RegisterUserException(string message) : base(message)
    {

    }
}