﻿using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.DTOs.Patient;
using MedicalClinic.Domain.Entities;
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

        public int PatientId { get; set; }
        public virtual PatientResponse Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public virtual DoctorResponse Doctor { get; set; } = null!;

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
