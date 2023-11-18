using MedicalClinic.Application.DTOs.Appointment;
using MedicalClinic.Application.DTOs.Availability;
using MedicalClinic.Application.DTOs.Forwarding;
using MedicalClinic.Application.DTOs.Medication;
using MedicalClinic.Application.DTOs.Specialty;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Prescription
{
    public class PrescriptionResponse
    {
        public PrescriptionResponse()
        {
            Medications = new HashSet<MedicationResponse>();
            Forwardings = new HashSet<ForwardingResponse>();
        }
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public AppointmentResponse Appointment { get; set; } = null!;
        public string Observation { get; set; } = null!;

        public virtual ICollection<MedicationResponse> Medications { get; set; }
        public virtual ICollection<ForwardingResponse> Forwardings { get; set; }
    }
}
