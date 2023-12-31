﻿using MedicalClinic.Application.DTOs.Doctor;
using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Availability
{
    public  class AvailabilityResponse
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public virtual DoctorResponse Doctor { get; set; } = null!;

        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsEnabled { get; set; }
    }
}
