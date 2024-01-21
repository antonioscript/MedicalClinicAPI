using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MedicalClinic.Domain.Entities
{
    //TODO: Maybe to add a prop of DateOfProcedure
    public partial class Procedure
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; } = null!;

        public int TechnicianId { get; set; }
        public virtual Technician Technician { get; set; } = null!;

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; } = null!;

        public string? Observation { get; set; }

        public DateTime ProcedureDate { get; set; }
        public StatusCode Status { get; set; }

        public bool IsEnabled { get; set; }
        public DateTime? DeletedAt { get; set; }  
    }
}
