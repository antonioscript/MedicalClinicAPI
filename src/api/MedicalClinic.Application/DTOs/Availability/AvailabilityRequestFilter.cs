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
        public int Id { get; set; }
        public int DoctorId { get; set; }

        /// <summary>
        /// The day of the week when the doctor is available:
        /// 0: Monday
        /// 1: Tuesday
        /// 2: Wednesday
        /// 3: Thursday
        /// 4: Friday
        /// 5: Saturday
        /// 6: Sunday
        /// </summary>
        public byte DayOfWeek { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsEnabled { get; set; }
    }
}
