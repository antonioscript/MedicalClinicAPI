using MedicalClinic.Application.DTOs.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.Application.DTOs.Specialty
{
    public class SpecialtyRequestFilter
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? ConsultationValue { get; set; }
        public int? AppointmentDuration { get; set; }

        public bool? IsEnabled { get; set; }
    }
}
