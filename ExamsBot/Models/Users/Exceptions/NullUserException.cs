// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.Users.Exceptions
{
    public class NullUserException : Exception
    {
        public NullUserException() : base(message: "The user is null.") { }
    }
}
