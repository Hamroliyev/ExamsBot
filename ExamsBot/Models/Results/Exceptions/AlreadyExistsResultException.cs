// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class AlreadyExistsResultException : Xeption
    {
        public AlreadyExistsResultException(Exception innerException)
            : base(message: "Result with the same id already exists.", innerException) { }
    }
}