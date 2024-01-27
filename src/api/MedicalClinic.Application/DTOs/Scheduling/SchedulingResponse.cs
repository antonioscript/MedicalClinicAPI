using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.DTOs.Insurance;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.DTOs.Procedure;
using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Scheduling
{
    public class SchedulingResponse
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public SchedulingCodeDto SchedulingType { get; set; }
        public DateTime SchedulingDate { get; set; }

        public StatusCodeDto Status { get; set; }
        public string? Observation { get; set; }
    }
}
