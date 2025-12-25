// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using Xeptions;

namespace ExamsBot.Models.Results.Exceptions
{
    public class LockedResultException : Xeption
    {
        public LockedResultException(Exception innerException)
            : base(message: "Locked result record exception, please try again later.", innerException) { }
    }
}