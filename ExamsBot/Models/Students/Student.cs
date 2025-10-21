// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ExamsBot.Models.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdatedBy { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentSemesterCourse> StudentSemesterCourses { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentGuardian> StudentGuardians { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentContact> StudentContacts { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentExam> StudentExams { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentAttachment> StudentAttachments { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentExamFee> StudentExamFees { get; set; }

        [JsonIgnore]
        public IEnumerable<StudentRegistration> StudentRegistrations { get; set; }
    }
}
