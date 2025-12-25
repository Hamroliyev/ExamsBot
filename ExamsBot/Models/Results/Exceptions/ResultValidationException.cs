// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class ResultValidationException : Xeption
    {
        public ResultValidationException(Exception innerException)
            : base(message: "Result validation error occurred, fix the errors and try again.", innerException) 
        { }
    }
}