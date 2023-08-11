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
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal ConsultationValue { get; set; }

        public bool IsEnabled { get; set; }


        public virtual ICollection<DoctorResponse> Doctors { get; set; }
    }
}
