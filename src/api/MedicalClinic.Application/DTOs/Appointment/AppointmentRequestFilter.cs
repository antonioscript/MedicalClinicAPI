using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Appointment
{
    public class AppointmentRequestFilter
    {
        public int? PatientId { get; set; }

        public int? RequestingDoctorId { get; set; }

        public int? DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public AppointmentStatusCodeDto? Status { get; set; }

        public string? Observation { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
