// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class ResultDependencyException : Xeption
    {
        public ResultDependencyException(Exception innerException)
            : base(message: "Result dependency error occurred, contact support.", innerException) 
        { }
    }
}