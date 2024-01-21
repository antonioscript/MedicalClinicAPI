using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Appointment
{
    public class AppointmentResponse
    {
        public int Id { get; set; }

        public int? RequestingDoctorId { get; set; }
        public virtual DoctorResponse? RequestingDoctor { get; set; } = null!;

        public int PatientId { get; set; }
        public virtual PatientResponse Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public virtual DoctorResponse Doctor { get; set; } = null!;

        public DateTime AppointmentDate { get; set; } 

        public StatusCodeDto Status { get; set; }
        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }
    }
}
