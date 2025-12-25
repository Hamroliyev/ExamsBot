// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class NullResultException : Xeption
    {
        public NullResultException()
            : base(message: "The result is null.") { }
    }
}
