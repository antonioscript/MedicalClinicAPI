using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    public partial class Exam
    {
        public Exam()
        {
            Procedures = new HashSet<Procedure>();
        }

        /// <summary>
        /// Unique identifier for each medical exam
        /// </summary>
        public int ExamId { get; set; }
        /// <summary>
        /// The name of the exam
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Description of the exam
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// The Value of Exam
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Procedure> Procedures { get; set; }
    }
}
