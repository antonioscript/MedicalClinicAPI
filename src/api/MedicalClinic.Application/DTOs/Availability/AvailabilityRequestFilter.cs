using MedicalClinic.Application.Enums;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Availability
{
    public  class AvailabilityRequestFilter
    {
        public int? Id { get; set; }
        public int? DoctorId { get; set; }

        public AvailabilityDayOfWeekCodeDto? DayOfWeek { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public int? AppointmentDuration { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
