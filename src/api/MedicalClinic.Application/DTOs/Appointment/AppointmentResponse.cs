using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Appointment
{
    public class AppointmentResponse
    {
        /// <summary>
        /// Unique identifier for each medical appointment
        /// </summary>
        public int AppointmentId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the patient associated with the appointment
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// Foreign key referencing the unique identifier of the doctor associated with the appointment
        /// </summary>
        public int DoctorId { get; set; }
        /// <summary>
        /// Indicates the Status of the Query, being:
        /// 0:Scheduled
        /// 1:Confirmed
        /// 2: Cancelled
        /// </summary>
        public byte Status { get; set; }
        /// <summary>
        /// Additional observation or notes related to the appointment
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
    }
}
