using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.CanceledAppointment
{
    public class CanceledAppointmentResponse
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }
        public string? ReasonCancellation { get; set; }
        public DateTime CancellationDate { get; set; }
    }
}
