// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Results.Exceptions
{
    public class InvalidResultException : Exception
    {
        public InvalidResultException(string parameterName, object parameterValue)
            : base(message: $"Invalid result, " +
                  $"parameter name: {parameterName}, " +
                  $"parameter value: {parameterValue}.")
        { }
    }
}