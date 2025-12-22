// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Assignments;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<StudentAssignment> InsertStudentAssignmentAsync(StudentAssignment assignment);
        IQueryable<StudentAssignment> SelectAllStudentAssignments();
        ValueTask<StudentAssignment> SelectStudentAssignmentByIdAsync(Guid assignmentId);
        ValueTask<StudentAssignment> UpdateStudentAssignmentAsync(StudentAssignment assignment);
        ValueTask<StudentAssignment> DeleteStudentAssignmentAsync(StudentAssignment assignment);
    }
}
