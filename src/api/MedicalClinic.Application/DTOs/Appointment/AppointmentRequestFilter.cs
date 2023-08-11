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
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        /// <summary>
        /// Indicates the Status of the Query, being:
        /// 0:Scheduled
        /// 1:Confirmed
        /// 2: Cancelled
        /// </summary>
        public byte Status { get; set; }

        public string? Observation { get; set; }
        public bool IsEnabled { get; set; }
    }
}
