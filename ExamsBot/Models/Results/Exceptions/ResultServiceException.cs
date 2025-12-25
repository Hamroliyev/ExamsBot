// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class ResultServiceException : Xeption
    {
        public ResultServiceException(Exception innerException)
            : base(message: "Result service error occurred, contact support.", innerException) { }
    }
}