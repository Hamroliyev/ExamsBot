// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Xeptions;

namespace ExamsBot.Models.Contacts.Exceptions
{
    public class InvalidContactException : Xeption
    {
        public InvalidContactException(string parameterName, object parameterValue)
            : base(message: $"Invalid Contact, " +
                  $"ParameterName: {parameterName}, " +
                  $"ParameterValue: {parameterValue}.")
        { }

        public InvalidContactException()
            : base(message: "Invalid contact. Please fix the errors and try again.") { }
    }
}
