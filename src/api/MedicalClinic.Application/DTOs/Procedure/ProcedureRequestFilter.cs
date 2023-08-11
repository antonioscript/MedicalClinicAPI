using MedicalClinic.Application.DTOs.Exam;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Procedure
{
    public class ProcedureRequestFilter
    {
        public int PatientId { get; set; }

        public int TechnicianId { get; set; }
        public int ExamId { get; set; }

        public string? Observation { get; set; }

        public bool IsEnabled { get; set; }
    }
}
