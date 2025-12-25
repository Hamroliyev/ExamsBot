// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class NotFoundResultException : Xeption
    {
        public NotFoundResultException(Guid resultId)
            : base(message: $"Couldn't find result with id: {resultId}.") { }
    }
}