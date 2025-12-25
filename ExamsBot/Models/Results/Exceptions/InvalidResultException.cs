// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class InvalidResultException : Xeption
    {
        public InvalidResultException()
            : base(message: "Invalid result. Please fix the errors and try again.") { }
    }
}