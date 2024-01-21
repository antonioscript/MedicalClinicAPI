using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.DTOs.Technician;
using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Procedure
{
    public class ProcedureResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual PatientResponse Patient { get; set; } = null!;

        public int TechnicianId { get; set; }
        public virtual TechnicianResponse Technician { get; set; } = null!;

        public int ExamId { get; set; }
        public virtual ExamResponse Exam { get; set; } = null!;

        public string? Observation { get; set; }

        public DateTime ProcedureDate { get; set; }
        public StatusCodeDto Status { get; set; }

        public bool IsEnabled { get; set; }
    }
}
