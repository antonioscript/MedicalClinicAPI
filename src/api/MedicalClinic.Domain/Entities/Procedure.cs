using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    /// <summary>
    /// Stores information about medical procedures and exams performed on patients
    /// </summary>
    public partial class Procedure
    {
        /// <summary>
        /// Unique identifier for each medical procedure
        /// </summary>
        public int ProcedureId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the patient associated with the procedure
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the technician performing the procedure
        /// </summary>
        public int TechnicianId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the exam associated with the procedure
        /// </summary>
        public int ExamId { get; set; }
        /// <summary>
        /// Additional observation or notes related to the procedure
        /// </summary>
        public string? Observation { get; set; }
        /// <summary>
        /// Indicates if the record  is currently active in the system
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// The date when the record  was logically deleted from the system
        /// </summary>
        public DateTime? DeletedAt { get; set; }

        public virtual Exam Exam { get; set; } = null!;
        public virtual Patient Patient { get; set; } = null!;
        public virtual Technician Technician { get; set; } = null!;
    }
}
