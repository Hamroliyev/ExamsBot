// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;

namespace ExamsBot.Models.AssignmentAttachments
{
    public class AssignmentAttachment
    {
        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public Guid AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        public string Notes { get; set; }
    }
}
